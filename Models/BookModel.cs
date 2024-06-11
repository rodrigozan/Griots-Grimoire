using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

public class BookModel
{
    public BookModel(
        string title, 
        string initialIdea,
        string writerId, 
        string coWritersId, 
        string genrer, 
        string style, 
        string targetAudience, 
        string marketShare, 
        string firstResume, 
        string worldBuildingId, 
        string charactersId, 
        string secondResume, 
        List<string> threeActsStructure,
        List<string> tramaPoints,
        List<string> scenes,
        DateTime createData, 
        string thirdResume,
        DateTime updateDate
        )
    {
        this.Id = ObjectId.GenerateNewId();
        this.InitialIdea = initialIdea;
        this.Title = title;
        this.WriterId = writerId;
        this.CoWritersId = coWritersId;
        this.Genrer = genrer;
        this.Style = style;
        this.TargetAudience = targetAudience;
        this.MarketShare = marketShare;
        this.FirstResume = firstResume;
        this.WorldBuildingId = worldBuildingId;
        this.CharactersId = charactersId;
        this.SecondResume = secondResume;
        this.ThreeActsStructure = threeActsStructure;
        this.TramaPoints = tramaPoints;
        this.Scenes = scenes;
        this.ThirdResume = thirdResume;
        this.CreateData = createData;
        this.UpdateDate = updateDate;

    }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    public string InitialIdea { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    [BsonRepresentation(BsonType.ObjectId)]
    public string WriterId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string CoWritersId { get; set; }

    [Required]
    public string Genrer { get; set; }

    [Required]
    public string Style { get; set; }

    public string TargetAudience { get; set; }

    public string MarketShare { get; set; }

    [Required]
    public string FirstResume { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string WorldBuildingId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string CharactersId { get; set; }

    public string SecondResume { get; set; }

    public List<string> ThreeActsStructure { get; set; }

    public List<string> TramaPoints { get; set; }    

    public List<string> Scenes { get; set; }

    public string ThirdResume { get; set; }

    public DateTime CreateData { get; set; }

    public DateTime UpdateDate { get; set; }

}
