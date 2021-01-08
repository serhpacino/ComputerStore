using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Domain.Entities
{
   public class ComputerComponent
    {
        public int ComputerComponentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }

    }
}
