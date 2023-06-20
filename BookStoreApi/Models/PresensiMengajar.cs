using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace BookStoreApi.Models;

public class PresensiMengajar
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    [JsonPropertyName("Name")]

    public string NIP { get; set; } = null!;
    public string Tanggal { get; set; } = null!;
    public string Kehadiran { get; set; } = null!;
    public string Kelas { get; set; } = null!;
}