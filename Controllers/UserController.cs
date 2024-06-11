using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMongoCollection<UserModel> _userCollection;

    public UserController(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("GriotsGrimoire");
        _userCollection = database.GetCollection<UserModel>("Users");
    }

    // GET: api/User
    [HttpGet]
    public IEnumerable<UserModel> Get()
    {
        return _userCollection.Find(new BsonDocument()).ToList();
    }

    // GET: api/User/123abc
    [HttpGet("{id}", Name = "GetUser")]
    public ActionResult<UserModel> Get(string id)
    {
        var objectId = ObjectId.Parse(id);
        var user = _userCollection.Find(u => u.Id == objectId).FirstOrDefault();
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }

    // POST: api/User
    [HttpPost]
    public IActionResult Post([FromBody] UserModel user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _userCollection.InsertOne(user);
        return CreatedAtRoute("GetUser", new { id = user.Id }, user);
    }

    // PUT: api/User/5
    [HttpPut("{id}")]
    public IActionResult Put(string id, [FromBody] UserModel user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var objectId = ObjectId.Parse(id);
        var filter = Builders<UserModel>.Filter.Eq(u => u.Id, objectId);
        var update = Builders<UserModel>.Update
            .Set(u => u.Name, user.Name)
            .Set(u => u.Email, user.Email)
            .Set(u => u.Password, user.Password)
            .Set(u => u.Sex, user.Sex)
            .Set(u => u.DateOfBirth, user.DateOfBirth)
            .Set(u => u.RegisterUpdate, DateTime.Now)
            .Set(u => u.Role, user.Role);

        var result = _userCollection.UpdateOne(filter, update);
        if (result.ModifiedCount == 0)
        {
            return NotFound();
        }

        return Ok(result);
    }

    // DELETE: api/User/5
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var objectId = ObjectId.Parse(id);
        var result = _userCollection.DeleteOne(u => u.Id == objectId);
        if (result.DeletedCount == 0)
        {
            return NotFound();
        }

        return NoContent();
    }
}
