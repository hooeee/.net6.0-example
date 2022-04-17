using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTech.AutoMapper.Dtos;
using TeamTech.AutoMapper.Entities;

namespace TeamTech.AutoMapper
{
    public class AutoMapperTest
    {

        private MemberDto _getDto()
        {

            return new MemberDto()
            {
                Name = "test",
                Tel = "010-3333-3333"
            };
        }

        private MemberDto _getRelationDto()
        {
            var dto = new MemberDto()
            {
                Name = "test",
                Tel = "010-3333-3333",
                Department = new DepartmentDto()
                {
                    Id = 1,
                    Name = "aa"
                }
            };

            dto.Department.members = new List<MemberDto>() { dto };

            return dto;
        }

        private DeliveryDto _getDeliveryDto()
        {
            return new DeliveryDto()
            {
                Id = 99,
                OrdererName = "주문자 이름.",
                Address1 = "서울 특별시",
                Address2 = "마포구",
                Address3 = "연남동",
            };
        }

        private Member _getEntity()
        {
            return new Member()
            {
                Name = "test",
                Tel = "010-3333-3333"
            };
        }

        public void Test()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Object, Object>());
            var mapper = new Mapper(config);


            var dto = _getDto();

            // 타입을 지정해주지 않아서 오류가 남.
            var entity = mapper.Map<Member>(dto);
        }



        public void Test2()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Member, MemberDto>();
                cfg.CreateMap<MemberDto, Member>();
            });
            var mapper = new Mapper(config);


            var dto = _getDto();

            var entity = mapper.Map<Member>(dto);
            var mappingDto = mapper.Map<MemberDto>(entity);
        }


        public void Test3()
        {
            // 순환참조 알아서 끊어줌.
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Member, MemberDto>().ReverseMap();
                cfg.CreateMap<Department, DepartmentDto>().ReverseMap();
            });
            var mapper = new Mapper(config);

            var dto = _getRelationDto();

            var entity = mapper.Map<Member>(dto);
            var mappingDto = mapper.Map<MemberDto>(entity);

        }


        public void Test4()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DeliveryDto, Delivery>()
                    .ForMember(src => src.Address, option => option.MapFrom(dto => $"{dto.Address1}_{dto.Address2}_{dto.Address3}"))
                    .ForMember(src => src.OrdererFirstName, option => option.Ignore())
                    .ForMember(src => src.OrdererLastName, option => option.Ignore())
                    .AfterMap((dto, entity) => {
                        var nameSplite = dto.OrdererName.Split(" ");
                        entity.OrdererFirstName = nameSplite[0];
                        entity.OrdererLastName = nameSplite[1];
                    })
                    .ReverseMap()
                    .ForMember(src=> src.Address1 , option => option.Ignore())
                    .ForMember(src => src.OrdererName, option => option.MapFrom(entity => $"{entity.OrdererFirstName} {entity.OrdererLastName}"))
                    .AfterMap((entity , dto) =>
                    {
                        var addressSplite = entity.Address.Split("_");
                        dto.Address1 = addressSplite[0];
                        dto.Address2 = addressSplite[1];
                        dto.Address3 = addressSplite[2];
                    })
                    ;
            });
            var mapper = new Mapper(config);

            var dto = _getDeliveryDto();

            var entity = mapper.Map<Delivery>(dto);
            var mappingDto = mapper.Map<DeliveryDto>(entity);
        }
    }
}
