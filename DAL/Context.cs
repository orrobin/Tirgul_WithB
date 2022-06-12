using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Threading.Tasks;

namespace DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<Lender> Lenders { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<ExtendedField> ExtendedFields { get; set; }
    }
}
