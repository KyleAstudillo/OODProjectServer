using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OODProjectServer.Entities;

namespace OODProjectServer.Entities
{
    public class UserItem
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateStarted { get; set; }
        public int Rank { get; set; }
        public int UserId { get; set; }
        public List<CoffeeItem> CoffeeItems { get; set; }

        public UserItem(string FirstName,
        string LastName,
            string Email,
            int Rank,
            int UserId)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.DateStarted = DateTime.Now;
            this.Rank = Rank;
            this.UserId = UserId;
            this.CoffeeItems = new List<CoffeeItem>();
        }

        public UserItem() { }
    }
}
