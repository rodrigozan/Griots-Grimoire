using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Microsoft.AspNetCore.Identity;


public class UserModel
{

    public UserModel(string firstName, string lastName, string username, string email, string password, char genrer, DateTime dateOfBirth, string address, string city, string country, string role, DateTime registerDate, DateTime registerUpdate)
    {
        this.Id = ObjectId.GenerateNewId();
        this.FirstName  = firstName;
        this.LastName  = lastName;
        this.Username = username;
        this.Email = email;
        this.Password = password;
        this.Genrer = genrer;
        this.DateOfBirth = dateOfBirth;
        this.Address = address;
        this.City = city;
        this.Country = country;
        this.RegisterDate = DateTime.Now;
        this.RegisterUpdate = DateTime.Now;
        this.Role = role;

    }
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    public char Genrer { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Address { get; set; }

    public string City { get; set; }

    public string Country { get; set; }

    public DateTime RegisterDate { get; set; }

    public DateTime RegisterUpdate { get; set; }

    public string Role { get; set; }   

}
