using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class CharacterController : ControllerBase
{
    private readonly IMongoCollection<CharacterModel> _characterCollection;

    public CharacterController(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("GriotsGrimoire");
        _characterCollection = database.GetCollection<CharacterModel>("Characters");
    }

    // GET: api/Character
    [HttpGet]
    public IEnumerable<CharacterModel> Get()
    {
        return _characterCollection.Find(new BsonDocument()).ToList();
    }

    // GET: api/Character/5
    [HttpGet("{id}", Name = "GetCharacter")]
    public ActionResult<CharacterModel> Get(string id)
    {
        var objectId = ObjectId.Parse(id);
        var character = _characterCollection.Find(c => c.Id  == objectId).FirstOrDefault();
        if (character == null)
        {
            return NotFound();
        }
        return character;
    }

    // POST: api/Character
    [HttpPost]
    public IActionResult Create(CharacterModel character)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _characterCollection.InsertOne(character);
         return CreatedAtAction("GetCharacter", new { id = character.Id  }, character);
    }

    // PUT: api/Character/5
    [HttpPut("{id}")]
    public IActionResult Put(string id, [FromBody] CharacterModel character)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var objectId = ObjectId.Parse(id);
        var filter = Builders<CharacterModel>.Filter.Eq(c => c.Id, objectId);
        var update = Builders<CharacterModel>.Update
            .Set(c => c.Nome, character.Nome)
            .Set(c => c.Idade, character.Idade)
            .Set(c => c.Genero, character.Genero)
            .Set(c => c.Raca, character.Raca)
            .Set(c => c.Altura, character.Altura)
            .Set(c => c.Peso, character.Peso)
            .Set(c => c.Aparencia, character.Aparencia)
            .Set(c => c.Personalidade, character.Personalidade)
            .Set(c => c.Historico, character.Historico)
            .Set(c => c.Habilidades, character.Habilidades)
            .Set(c => c.Equipamentos, character.Equipamentos)
            .Set(c => c.Aliancas, character.Aliancas)
            .Set(c => c.Relacionamentos, character.Relacionamentos)
            .Set(c => c.ComportamentoDominante, character.ComportamentoDominante)
            .Set(c => c.ObjetivoPrincipal, character.ObjetivoPrincipal)
            .Set(c => c.Objetivos, character.Objetivos)
            .Set(c => c.Medos, character.Medos)
            .Set(c => c.Temperamento, character.Temperamento)
            .Set(c => c.Signos, character.Signos)
            .Set(c => c.Segredos, character.Segredos)
            .Set(c => c.Forcas, character.Forcas)
            .Set(c => c.Fraquezas, character.Fraquezas)
            .Set(c => c.Notas, character.Notas);

        var result = _characterCollection.UpdateOne(filter, update);
        if (result.ModifiedCount == 0)
        {
            return NotFound();
        }

        return Ok(result);
    }

    // Delete a character by ID
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
         var objectId = ObjectId.Parse(id);
        var result = _characterCollection.DeleteOne(c => c.Id == objectId);
        if (result.DeletedCount == 0)
        {
            return NotFound();
        }
        return NoContent();
    }
}
