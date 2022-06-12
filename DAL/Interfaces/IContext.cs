using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IContext<T> where T : Customer
    {
        public DbSet<T> Customers { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellation = new System.Threading.CancellationToken ());


    }
}
