using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTech.ORM.Entities.Models
{
    [Table("posts")]
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public int Updated { get; set; }
        public int BlogId { get; set; } = 1;
        public Blog Blog { get; set; }

    }
}
