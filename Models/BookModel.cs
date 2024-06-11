using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

public class BookModel
{

    public BookModel(string writerId, List<string> coWritersId, string worldbuildingId, List<string> charactersId, string title, string targetAudience, string marketShare, string genrer, string style, string firstResume, DateTime createData, DateTime updateDate)
    {
        this.Id = ObjectId.GenerateNewId();
        this.WriterId = writerId;
        this.CoWritersId = coWritersId;
        this.WorldbuildingId = worldbuildingId;
        this.CharactersId = charactersId;
        this.Title = title;
        this.TargetAudience = targetAudience;
        this.MarketShare = marketShare;
        this.Genrer = genrer;
        this.Style = style;
        this.FirstResume = firstResume;
        this.CreateData = createData;
        this.UpdateDate = updateDate;
    }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    [BsonRepresentation(BsonType.ObjectId)]
    public string WriterId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> CoWritersId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string WorldbuildingId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> CharactersId { get; set; }

    [Required]
    public string TargetAudience { get; set; }

    [Required]
    public string MarketShare { get; set; }

    [Required]
    public string Genrer { get; set; }

    [Required]
    public string Style { get; set; }

    [Required]
    public string FirstResume { get; set; }

    public DateTime CreateData { get; set; }

    public DateTime UpdateDate { get; set; }

}
