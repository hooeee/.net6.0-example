using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEntity.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BlogId { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Post> Posts { set; get; }

    }
}
