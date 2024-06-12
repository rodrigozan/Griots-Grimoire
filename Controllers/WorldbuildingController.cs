using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class WorldbuildingController : ControllerBase
{
    private readonly IMongoCollection<WordBuildingModel> _wordBuildingCollection;

    public WorldbuildingController(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("GriotsGrimoire");
        _wordBuildingCollection = database.GetCollection<WordBuildingModel>("WordBuilding");
    }

    [HttpGet]
    public ActionResult<List<WordBuildingModel>> Get()
    {
        return _wordBuildingCollection.Find(world => true).ToList();
    }

    [HttpGet("{id}", Name = "GetWordBuilding")]
    public ActionResult<WordBuildingModel> Get(string id)
    {
        var objectId = ObjectId.Parse(id);
        var worldbuilding = _wordBuildingCollection.Find(world => world.Id == objectId).FirstOrDefault();
        if (worldbuilding == null)
        {
            return NotFound();
        }
        return worldbuilding;
    }

    [HttpPost]
    public ActionResult<WordBuildingModel> Create(WordBuildingModel worldbuilding)
    {
        _wordBuildingCollection.InsertOne(worldbuilding);
        return CreatedAtRoute("GetWordBuilding", new { id = worldbuilding.Id.ToString() }, worldbuilding);
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, WordBuildingModel worldbuildingIn)
    {
        var objectId = ObjectId.Parse(id);
        var filter = Builders<WordBuildingModel>.Filter.Eq(w => w.Id, objectId);
        var update = Builders<WordBuildingModel>.Update
            .Set(w => w.WorldName, worldbuildingIn.WorldName)
            .Set(w => w.Description, worldbuildingIn.Description)
            .Set(w => w.Races, worldbuildingIn.Races)
            .Set(w => w.Languages, worldbuildingIn.Languages)
            .Set(w => w.Locations, worldbuildingIn.Locations)
            .Set(w => w.Cultures, worldbuildingIn.Cultures)
            .Set(w => w.MagicSystems, worldbuildingIn.MagicSystems)
            .Set(w => w.Technologies, worldbuildingIn.Technologies)
            .Set(w => w.History, worldbuildingIn.History)
            .Set(w => w.Religions, worldbuildingIn.Religions)
            .Set(w => w.Creatures, worldbuildingIn.Creatures)
            .Set(w => w.Organizations, worldbuildingIn.Organizations)
            .Set(w => w.ImportantFigures, worldbuildingIn.ImportantFigures)
            .Set(w => w.Events, worldbuildingIn.Events)
            .Set(w => w.Artifacts, worldbuildingIn.Artifacts)
            .Set(w => w.Books, worldbuildingIn.Books)
            .Set(w => w.Miscellaneous, worldbuildingIn.Miscellaneous);


        var result = _wordBuildingCollection.UpdateOne(filter, update);
        if (result.ModifiedCount == 0)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var objectId = ObjectId.Parse(id);
        var worldbuilding = _wordBuildingCollection.Find(world => world.Id == objectId).FirstOrDefault();
        if (worldbuilding == null)
        {
            return NotFound();
        }
        _wordBuildingCollection.DeleteOne(world => world.Id == objectId);
        return NoContent();
    }
}
