using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SomeTests.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("SNM")]
        [Required]
        public string? SNM { get; set; }

        [BsonElement("Address")]
        public string? Address { get; set; }

        [BsonElement("Phone")]
        [Required]
        public ulong Phone { get; set; }

        [BsonElement("Subject_title")]
        [Required]
        public string? Subject_title { get; set; }

        [BsonElement("Lecture_hourse")]
        [Required]
        public uint Lecture_hourse { get; set; }

        [BsonElement("Practices_hourse")]
        [Required]
        public uint Practices_hourse { get; set; }

        [BsonElement("Laboratory_hourse")]
        [Required]
        public uint Laboratory_hourse { get; set; }
        
        [BsonElement("Semestry_number")]
        [Required]
        public uint Semestry_number { get; set; }
        
        [BsonElement("Mark")]
        [Required]
        public uint Mark { get; set; }

        [BsonElement("Semestr")]
        [Required]
        public uint Semestr { get; set; }
    }
}
