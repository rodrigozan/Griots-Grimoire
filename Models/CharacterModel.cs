using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

public class CharacterModel
{

    public CharacterModel(
        ObjectId id,  
        List<string> bookId,
        string worldBuildingId,
        string nome, 
        int idade, 
        string genero, 
        string raca, 
        double altura, 
        double peso, 
        string aparencia, 
        string personalidade, 
        string historico, 
        List<string> habilidades,
        List<string> equipamentos,
        List<string> aliancas,
        List<string> relacionamentos,
        List<string> comportamentoDominante,
        string objetivoPrincipal,
        List<string> objetivos,
        List<string> medos,
        List<string> temperamento,
        List<string> signos,
        List<string> segredos,
        List<string> forcas,
        List<string> fraquezas,
        string notas
    )
    {
        this.Id = id;
        this.BookId = bookId;
        this.WorldBuildingId = worldBuildingId; 
        this.Nome = nome;
        this.Idade = idade;
        this.Genero = genero;
        this.Raca = raca;
        this.Altura = altura;
        this.Peso = peso;
        this.Aparencia = aparencia;
        this.Personalidade = personalidade;
        this.Historico = historico;  
        this.Habilidades = habilidades;
        this.Equipamentos = equipamentos;
        this.Aliancas = aliancas;
        this.Relacionamentos = relacionamentos; 
        this.ComportamentoDominante = comportamentoDominante; 
        this.ObjetivoPrincipal = objetivoPrincipal;
        this.Objetivos = objetivos;
        this.Medos = medos;
        this.Temperamento = temperamento; 
        this.Signos = signos; 
        this.Segredos = segredos;
        this.Forcas = forcas; 
        this.Fraquezas = fraquezas; 
        this.Notas = notas;

    }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> BookId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string WorldBuildingId { get; set; }

    public string Nome { get; set; }

    [BsonElement("idade")]
    public int Idade { get; set; }

    [BsonElement("genero")]
    public string Genero { get; set; }

    [BsonElement("raca")]
    public string Raca { get; set; }

    [BsonElement("altura")]
    public double Altura { get; set; }

    [BsonElement("peso")]
    public double Peso { get; set; }

    [BsonElement("aparencia")]
    public string Aparencia { get; set; }

    [BsonElement("personalidade")]
    public string Personalidade { get; set; }

    [BsonElement("historico")]
    public string Historico { get; set; }

    [BsonElement("habilidades")]
    public List<string> Habilidades { get; set; }

    [BsonElement("equipamentos")]
    public List<string> Equipamentos { get; set; }

    [BsonElement("aliancas")]
    public List<string> Aliancas { get; set; }

    [BsonElement("relacionamentos")]
    public List<string> Relacionamentos { get; set; }

    [BsonElement("comportamento_dominante")]
    public List<string> ComportamentoDominante { get; set; }

    [BsonElement("objetivo_principal")]
    public string ObjetivoPrincipal { get; set; }

    [BsonElement("objetivos")]
    public List<string> Objetivos { get; set; }

    [BsonElement("medos")]
    public List<string> Medos { get; set; }

    [BsonElement("temperamento")]
    public List<string> Temperamento { get; set; }

    [BsonElement("signo")]
    public List<string> Signos { get; set; }

    [BsonElement("segredos")]
    public List<string> Segredos { get; set; }

    [BsonElement("forcas")]
    public List<string> Forcas { get; set; }

    [BsonElement("fraquezas")]
    public List<string> Fraquezas { get; set; }

    [BsonElement("notas")]
    public string Notas { get; set; }
}
