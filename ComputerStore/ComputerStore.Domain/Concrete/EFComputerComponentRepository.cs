using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerStore.Domain.Abstract;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Domain.Concrete
{
    public class EFComputerComponentRepository:IComputerComponentRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<ComputerComponent> ComputerComponents
        {
            get { return context.ComputerComponents; }
        }
    }
}
