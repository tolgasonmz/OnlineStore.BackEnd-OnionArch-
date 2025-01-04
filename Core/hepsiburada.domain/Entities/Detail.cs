using hepsiburada.domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hepsiburada.domain.Entities
{
    public class Detail : EntityBase,IEntityBase
    {
        public Detail() { }
        public Detail(int id,string title,string description) 
        {
            Title = title;
            Description = description;
            Id = id;
        }   

        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }

        public Category Category { get; set; }
        public required int CategoryId { get; set; }
    }
}
