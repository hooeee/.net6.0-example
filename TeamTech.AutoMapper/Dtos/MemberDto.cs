using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTech.AutoMapper.Dtos
{
    public class MemberDto
    {

        public string Name { get; set; }
        public string Tel { get; set; }

        public DepartmentDto Department { get; set; }
    }
}
