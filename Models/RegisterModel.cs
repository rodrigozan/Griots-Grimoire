using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Microsoft.AspNetCore.Identity;


public class RegisterModel
{

    // public RegisterModel(string firstName, string lastName, string username, string email, string password, char genrer, DateTime dateOfBirth, string address, string city, string country, string role, DateTime registerDate, DateTime registerUpdate)
    // {
    //     this.Id = ObjectId.GenerateNewId();
    //     this.FirstName  = firstName;
    //     this.LastName  = lastName;
    //     this.Username = username;
    //     this.Email = email;
    //     this.Password = password;
    //     this.Genrer = genrer;
    //     this.DateOfBirth = dateOfBirth;
    //     this.Address = address;
    //     this.City = city;
    //     this.Country = country;
    //     this.RegisterDate = DateTime.Now;
    //     this.RegisterUpdate = DateTime.Now;
    //     this.Role = role;

    // }

    public RegisterModel()
    {
        this.Id = ObjectId.GenerateNewId();
        this.RegisterDate = DateTime.Now;
        this.RegisterUpdate = DateTime.Now;
    }
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    public char? Genrer { get; set; }

    public DateTime? RegisterDate { get; set; }

    public DateTime? RegisterUpdate { get; set; }

    public string? Role { get; set; }   

}
