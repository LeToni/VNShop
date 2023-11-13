namespace Catalog.API.Entities;

[BsonIgnoreExtraElements]
public class CatalogItem
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]

    public string Id { get; set; }
    [BsonElement("title")]
    public string Name { get; set; }

    [BsonElement("price")]
    public decimal Price { get; set; }

    [BsonElement("description")]
    public string Description { get; set; }

    [BsonElement("category")]
    public string Category { get; set; }

    [BsonElement("image")]
    public string Image { get; set; }

    public CatalogRating rating { get; set; }
}

