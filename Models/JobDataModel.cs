using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace WebCrawlerExample.Models
{
    public class JobDataModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Link { get; set; }

        [Required]
        public string JobDetail { get; set; }
    }
}
