using System;
namespace OODProjectServer.Entities
{
    public class CoffeeItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageLink1 { get; set; }
        public string ImageLink2 { get; set; }
        public int UserId { get; set; }
        public int CoffeeId { get; set; }

        public CoffeeItem(string name, int userId, int coffeeId)
        {
            this.Name = name;
            this.UserId = userId;
            this.CoffeeId = coffeeId;
        }

        public CoffeeItem() { }
    }
}
