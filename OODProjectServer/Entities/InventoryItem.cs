namespace OODProjectServer.Entities
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public int CoffeeId { get; set; }
        public decimal Price { get; set; }
        public decimal PriceBought { get; set; }
        public int LocationId { get; set; }
        public int InventoryCount { get; set; }

    }
}
