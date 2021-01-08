using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerStore.Domain.Entities;
using System.Data.Entity;

namespace ComputerStore.Domain.Concrete
{
    public class EFDbContext:DbContext
    {
        public DbSet<ComputerComponent> ComputerComponents { get; set; }
    }
}
