using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTech.AutoMapper.Dtos
{
    public class DeliveryDto
    {
        public int Id { get; set; }

        public string OrdererName{ get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
    }
}
