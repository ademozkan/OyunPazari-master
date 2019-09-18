using OyunPazari.Core.Entity;
using System;
using System.Collections.Generic;

namespace OyunPazari.Model.Entities
{
    public enum Role
    {
        None=0,
        Member=2,
        Admin=4,
        Guest=6
    }

    public class AppUser:CoreEntity
    {
        public AppUser()
        {
            Orders = new List<Order>();
        }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImagePath { get; set; }

        //Sipariş İlişkisi
        public virtual ICollection<Order> Orders { get; set; }
    }
}
