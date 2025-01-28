using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.app.Features.Categorys.Command.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public int Priorty { get; set; }
    }
}
