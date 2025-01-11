using hepsiburada.domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hepsiburada.domain.Entities
{
    public class Detail : EntityBase
    {
        public Detail() { }
        public Detail(int id,string title,string description) 
        {
            Title = title;
            Description = description;
            Id = id;
        }   

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
