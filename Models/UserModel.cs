using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class UserModel
{

    public UserModel(string name, string email, string password, char sex, DateTime dateOfBirth, string role, DateTime registerDate, DateTime registerUpdate)
    {
        this.Id = ObjectId.GenerateNewId();
        this.Name = name;
        this.Email = email;
        this.Password = password;
        this.Sex = sex;
        this.DateOfBirth = dateOfBirth;
        this.RegisterDate = DateTime.Now;
        this.RegisterUpdate = DateTime.Now;
        this.Role = role;

    }
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public char Sex { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    public string Role { get; set; } // Usar enum para os papéis    

    public DateTime RegisterDate { get; set; }

    public DateTime RegisterUpdate { get; set; }

}
