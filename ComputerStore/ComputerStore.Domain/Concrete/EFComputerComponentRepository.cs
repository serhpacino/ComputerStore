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
        public void SaveProduct(ComputerComponent computercomponent)
        {
            if (computercomponent.ComputerComponentId == 0)
                context.ComputerComponents.Add(computercomponent);
            else
            {
                ComputerComponent dbEntry = context.ComputerComponents.Find(computercomponent.ComputerComponentId);
                if (dbEntry != null)
                {
                    dbEntry.Name = computercomponent.Name;
                    dbEntry.Description = computercomponent.Description;
                    dbEntry.Price = computercomponent.Price;
                    dbEntry.Category = computercomponent.Category;
                    dbEntry.ImageData = computercomponent.ImageData;
                    dbEntry.ImageMimeType = computercomponent.ImageMimeType;
                }
            }
            context.SaveChanges();
        }

        public ComputerComponent DeleteProduct(int computercomponentId)
        {
            ComputerComponent dbEntry = context.ComputerComponents.Find(computercomponentId);
            if (dbEntry != null)
            {
                context.ComputerComponents.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
