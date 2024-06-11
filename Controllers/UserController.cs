using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<Usuario> _usuariosCollection;

    public UsuariosController(IMongoClient mongoClient)
    {
        _database = mongoClient.GetDatabase("GriotsGrimoire");
        _usuariosCollection = _database.GetCollection<Usuario>("Usuarios");
    }

    // GET: api/Usuarios
    [HttpGet]
    public IEnumerable<Usuario> Get()
    {
        return _usuariosCollection.Find(new BsonDocument()).ToList();
    }

    // GET: api/Usuarios/5
    [HttpGet("{id}", Name = "GetUsuario")]
    public Usuario Get(int id)
    {
        return _usuariosCollection.Find(u => u.Id == id).FirstOrDefault();
    }

    // POST: api/Usuarios
    [HttpPost]
    public IActionResult Post([FromBody] Usuario usuario)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        usuario.Id = _usuariosCollection.AsQueryable().Count() + 1;
        usuario.DataCadastro = DateTime.Now;
        _usuariosCollection.InsertOne(usuario);

        return CreatedAtRoute("GetUsuario", new { id = usuario.Id }, usuario);
    }

    // PUT: api/Usuarios/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Usuario usuario)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var filter = Builders<Usuario>.Filter.Eq(u => u.Id, id);
        var update = Builders<Usuario>.Update
            .Set(u => u.Name, usuario.Name)
            .Set(u => u.Email, usuario.Email)
            .Set(u => u.Password, usuario.Password)
            .Set(u => u.Sexo, usuario.Sexo)
            .Set(u => u.DataNascimento, usuario.DataNascimento)
            .Set(u => u.Role, usuario.Role)
            .Set(u => u.DataAtualizacaoCadastro, DateTime.Now);

        var result = _usuariosCollection.UpdateOne(filter, update);
        if (result.ModifiedCount == 0)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/Usuarios/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _usuariosCollection.DeleteOne(u => u.Id == id);
        if (result.DeletedCount == 0)
        {
            return NotFound();
        }

        return NoContent();
    }
}
