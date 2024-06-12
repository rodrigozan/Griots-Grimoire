using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

public class CharacterModel
{
    public CharacterModel() {}

    public CharacterModel(ObjectId id, string nome, int idade, string genero, string raca, double altura, double peso, string aparencia, string personalidade, string historico, string notas)
    {
        this.Id = id;
        this.Nome = nome;
        this.Idade = idade;
        this.Genero = genero;
        this.Raca = raca;
        this.Altura = altura;
        this.Peso = peso;
        this.Aparencia = aparencia;
        this.Personalidade = personalidade;
        this.Historico = historico;
        this.Notas = notas;

    }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    [BsonElement("nome")]
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

    [BsonElement("objetivos")]
    public List<string> Objetivos { get; set; }

    [BsonElement("medos")]
    public List<string> Medos { get; set; }

    [BsonElement("temperamento")]
    public List<string> Temperamento { get; set; }

    [BsonElement("signo")]
    public List<string> Signo { get; set; }

    [BsonElement("signo_ascendente")]
    public List<string> SignoAscendente { get; set; }

    [BsonElement("segredos")]
    public List<string> Segredos { get; set; }

    [BsonElement("forcas")]
    public List<string> Forcas { get; set; }

    [BsonElement("fraquezas")]
    public List<string> Fraquezas { get; set; }

    [BsonElement("notas")]
    public string Notas { get; set; }
}
