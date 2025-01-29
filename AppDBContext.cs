using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpImplementation
{
    internal class AppDBContext : DbContext
    {
        public DbSet<DBModel> DBModels { get; set; }


    }
}
