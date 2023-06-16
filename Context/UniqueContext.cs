using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniqueTodoApplication.Entities;

namespace UniqueTodoApplication.Context
{
    public class UniqueContext : DbContext
    {
        public UniqueContext(DbContextOptions<UniqueContext> options) : base(options)
        {

        }

       public DbSet<Admin> Admins { get; set; }

        public  DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Subcategory> Subcategories { get; set; }

        public DbSet<ItemSubcategory> ItemSubcategories { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Reminder> Reminders { get; set; }

        public DbSet<Todoitem> Todoitems { get; set; }


    }
}
