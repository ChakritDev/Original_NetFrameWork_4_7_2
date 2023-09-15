using OriginalFrameWork4_7_2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OriginalFrameWork4_7_2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() :
          base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<EmployeeModel> DbEmployee { get; set; }
    }
}