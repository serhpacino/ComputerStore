using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Domain.Abstract
{
    public interface IComputerComponentRepository
    {
        IEnumerable<ComputerComponent> ComputerComponents { get; }
        void SaveProduct(ComputerComponent computercomponent);
        ComputerComponent DeleteProduct(int computercomponentId);
    }
}
