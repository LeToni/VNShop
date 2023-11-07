namespace Catalog.API.Entities;

public class CatalogRating
{
    [BsonElement("count")]
    public long Count { get; set; }

    [BsonElement("rate")]
    public double Rate { get; set; }

}
