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

            // 타입을 지정해주지 않아서 오류가 남.
            var entity = mapper.Map<Member>(dto);
        }
    }
}
