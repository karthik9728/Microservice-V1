using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrderWebApi.Models
{
    public class OrderDetail
    {
        //From mysql database
        [BsonElement("product_id"),BsonRepresentation(BsonType.Int32)]
        public int ProductId { get; set; }

        [BsonElement("quanity"), BsonRepresentation(BsonType.Decimal128)]
        public decimal Quanitiy { get; set; }

        [BsonElement("unit_price"), BsonRepresentation(BsonType.Decimal128)]
        public decimal UnitPrice { get; set; }
    }
}
