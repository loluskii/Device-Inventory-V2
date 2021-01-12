using DeviceInventory.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceInventory.Repositories
{
    public abstract class RepositoryBase
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

    }
}
