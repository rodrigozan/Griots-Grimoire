using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IMongoCollection<BookModel> _bookCollection;

    public BookController(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("GriotsGrimoire");
        _bookCollection = database.GetCollection<BookModel>("Books");
    }

    // GET: api/Book
    [HttpGet]
    public IEnumerable<BookModel> Get()
    {
        return _bookCollection.Find(new BsonDocument()).ToList();
    }

    // GET: api/Book/5
    [HttpGet("{id}", Name = "GetBook")]
    public ActionResult<BookModel> Get(string id)
    {
        var objectId = ObjectId.Parse(id);
        var book = _bookCollection.Find(b => b.Id == objectId).FirstOrDefault();
        if (book == null)
        {
            return NotFound();
        }
        return book;
    }


    // POST: api/Book
    [HttpPost]
    public IActionResult Post([FromBody] BookModel book)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _bookCollection.InsertOne(book);
        return CreatedAtRoute("GetBook", new { id = book.Id }, book);
    }

    // PUT: api/Book/5
    [HttpPut("{id}")]
    public IActionResult Put(string id, [FromBody] BookModel book)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var objectId = ObjectId.Parse(id);
        var filter = Builders<BookModel>.Filter.Eq(b => b.Id, objectId);
        var update = Builders<BookModel>.Update
            .Set(b => b.Title, book.Title)
            .Set(b => b.WriterId, book.WriterId)
            .Set(b => b.CoWritersId, book.CoWritersId)
            .Set(b => b.WorldbuildingId, book.WorldbuildingId)
            .Set(b => b.CharactersId, book.CharactersId)
            .Set(b => b.TargetAudience, book.TargetAudience)
            .Set(b => b.MarketShare, book.MarketShare)
            .Set(b => b.Genrer, book.Genrer)
            .Set(b => b.Style, book.Style)
            .Set(b => b.FirstResume, book.FirstResume)
            .Set(b => b.UpdateDate, DateTime.Now);

        var result = _bookCollection.UpdateOne(filter, update);
        if (result.ModifiedCount == 0)
        {
            return NotFound();
        }

        return Ok(result);
    }


    // DELETE: api/Book/5
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var objectId = ObjectId.Parse(id);
        var result = _bookCollection.DeleteOne(b => b.Id == objectId);
        if (result.DeletedCount == 0)
        {
            return NotFound();
        }

        return NoContent();
    }

}
