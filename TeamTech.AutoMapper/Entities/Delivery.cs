using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTech.AutoMapper.Entities
{
    public class Delivery
    {
        public int Id { get; set; }

        public string OrdererFirstName { get; set; }
        public string OrdererLastName { get; set; }

        public string Address { get; set; }
    }
}
