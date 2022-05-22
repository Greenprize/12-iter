using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SomeTests.Models
{
    public class Sale
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Customer")]
        [Required]
        public string? Customer { get; set; }

        [BsonElement("Discount")]
        [Required]
        public uint Discount { get; set; }

        [BsonElement("DateOfSale")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:HH/mm/dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        public string? DateOfSale { get; set; }

        [BsonElement("ProductType")]
        [Required]
        public string? ProductType { get; set; }

        [BsonElement("ProductWeight")]
        [Required]
        public double ProductWeight { get; set; }

        [BsonElement("ProductMaterial")]
        [Required]
        public string? ProductMaterial { get; set; }

        [BsonElement("ProductPrice")]
        [Required]
        public ulong ProductPrice { get; set; }
    }
}
