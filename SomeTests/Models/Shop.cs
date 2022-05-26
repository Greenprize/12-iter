using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SomeTests.Models
{
    public class Shop
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("ClientName")]
        [Required]
        public string? ClientName { get; set; }

        [BsonElement("Address")]
        [Required]
        public string? Address { get; set; }

        [BsonElement("Phone")]
        [Required]
        public ulong Phone { get; set; }

        [BsonElement("SaleDate")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:HH/mm/dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        public string? SaleDate { get; set; }

        [BsonElement("DeliveryDate")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:HH/mm/dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        public string? DeliveryDate { get; set; }

        [BsonElement("Product")]
        [Required]
        public string? Product { get; set; }

        [BsonElement("Price")]
        [Required]
        public uint Price { get; set; }

        [BsonElement("Quantity")]
        [Required]
        public uint Quantity { get; set; }
    }
}
