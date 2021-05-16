using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business_Cards_Web_API.Model
{
    public class BusinessCard
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Position { get; set; }

        public string Company {get; set;}

        public string ContactNumber { get; set; }

        public string Email { get; set; }

    }
}
