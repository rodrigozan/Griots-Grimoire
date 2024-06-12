using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

public class WordBuildingModel
{
    public WordBuildingModel(string worldName, string description, List<Races> races, List<string> languages, List<Locations> locations, List<string> cultures, List<MagicSystems> magicSystems, List<string> technologies, List<string> history, List<string> religions, List<string> creatures, List<string> organizations, List<string> importantFigures, List<string> events, List<string> artifacts, List<string> books, List<string> miscellaneous)
    {
        this.Id = ObjectId.GenerateNewId();
        this.WorldName = worldName;
        this.Description = description;
        this.Races = races;
        this.Languages = languages;
        this.Locations = locations;
        this.Cultures = cultures;
        this.MagicSystems = magicSystems;
        this.Technologies = technologies;
        this.History = history;
        this.Religions = religions;
        this.Creatures = creatures;
        this.Organizations = organizations;
        this.ImportantFigures = importantFigures;
        this.Events = events;
        this.Artifacts = artifacts;
        this.Books = books;
        this.Miscellaneous = miscellaneous;
    }


    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    public string WorldName { get; set; }

    public string Description { get; set; }

    public List<Races> Races { get; set; }

    public List<string> Languages { get; set; }

    public List<Locations> Locations { get; set; }

    public List<string> Cultures { get; set; }

    public List<MagicSystems> MagicSystems { get; set; }

    public List<string> Technologies { get; set; }

    public List<string> History { get; set; }

    public List<string> Religions { get; set; }

    public List<string> Creatures { get; set; }

    public List<string> Organizations { get; set; }

    [Required]
    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> ImportantFigures { get; set; }

    public List<string> Events { get; set; }

    public List<string> Artifacts { get; set; }

    [Required]
    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> Books { get; set; }

    public List<string> Miscellaneous { get; set; }
}

public class Races
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Origin { get; set; }

    public string Appearance { get; set; }

    public string Abilities { get; set; }

    public string Culture { get; set; }

    [Required]
    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> ImportantFigures { get; set; }

    public string Society { get; set; }

    public string Relations { get; set; }

    public string History { get; set; }

    public string Notes { get; set; }

}

public class Locations
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }

    public string Type { get; set; } //  if this location is a kingdom, a country, a city

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    [Required]
    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> ImportantFigures { get; set; }

    public double Description { get; set; }

    public double History { get; set; }
}

public class MagicSystems
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Source { get; set; }

    public string Rules { get; set; }

    public string Types { get; set; }

    public string Limitations { get; set; }

    public string Application { get; set; }

    public string RelationToSociety { get; set; }

    [Required]
    [BsonRepresentation(BsonType.ObjectId)]
    public string NotablePractitioners { get; set; }

    public string Mysteries { get; set; }

    public string Variants { get; set; }

    public string Notes { get; set; }

}

public class Organizations
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }

    public string Type { get; set; }

    public string Description { get; set; }

    public string Purpose { get; set; }

    public string Structure { get; set; }

    public string Goals { get; set; }

    public string Beliefs { get; set; }

    public string Influence { get; set; }

    public string Relations { get; set; }

    public string Assets { get; set; }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string NotableMembers { get; set; }

    public string Challenges { get; set; }

    public string Notes { get; set; }

}

public class Creature
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }

    public string Type { get; set; }

    public string Description { get; set; }

    public string Habitat { get; set; }

    public string Behavior { get; set; }

    public string Abilities { get; set; }

    public string Weaknesses { get; set; }

    public string Diet { get; set; }

    public string ThreatLevel { get; set; }

    public string Uses { get; set; }

    public string Legends { get; set; }

    public string Notes { get; set; }

}

public class Religion
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Pantheon { get; set; }

    public string Beliefs { get; set; }

    public string Practices { get; set; }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Clergy { get; set; }

    public string Temples { get; set; }

    public string HolyTexts { get; set; }

    public string Symbols { get; set; }

    public string Influence { get; set; }

    public string Relations { get; set; }

    public string Controversies { get; set; }

    public string Notes { get; set; }

}
