using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Business_Cards_Web_API.Model;

namespace Business_Cards_Web_API.Models
{
    public class Business_Cards_DataContext : DbContext
    {
        public Business_Cards_DataContext (DbContextOptions<Business_Cards_DataContext> options)
            : base(options)
        {
        }

        public DbSet<Business_Cards_Web_API.Model.BusinessCard> BusinessCard { get; set; }
    }
}
