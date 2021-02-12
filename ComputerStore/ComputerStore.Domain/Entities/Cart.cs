using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Domain.Entities
{
   public class Cart
    {
        
            private List<CartLine> lineCollection = new List<CartLine>();

            public void AddItem(ComputerComponent component, int quantity)
            {
                CartLine line = lineCollection
                    .Where(g => g.ComputerComponent.ComputerComponentId == component.ComputerComponentId)
                    .FirstOrDefault();

                if (line == null)
                {
                    lineCollection.Add(new CartLine
                    {
                        ComputerComponent = component,
                        Quantity = quantity
                    });
                }
                else
                {
                    line.Quantity += quantity;
                }
            }

            public void RemoveLine(ComputerComponent component)
            {
                lineCollection.RemoveAll(l => l.ComputerComponent.ComputerComponentId == component.ComputerComponentId);
            }

            public decimal ComputeTotalValue()
            {
                return lineCollection.Sum(e => e.ComputerComponent.Price * e.Quantity);

            }
            public void Clear()
            {
                lineCollection.Clear();
            }

            public IEnumerable<CartLine> Lines
            {
                get { return lineCollection; }
            }
        }

        public class CartLine
        {
            public ComputerComponent ComputerComponent { get; set; }
            public int Quantity { get; set; }
        }
    
}
