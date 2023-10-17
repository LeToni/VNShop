namespace Catalog.API.Entities
{
    public class CatalogItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("title")]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public CatalogCategory Category { get; set; }
        public string Image { get; set; }
        public CatalogRating Rating { get; set; }
    }
}
