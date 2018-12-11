using System;
namespace OODProjectServer.Entities
{
    public class LocationItem
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
    }
}
