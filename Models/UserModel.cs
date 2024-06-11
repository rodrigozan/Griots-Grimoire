using System.ComponentModel.DataAnnotations;

public class Usuario
{


    public Usuario(int id, string name, string email, string password, char sexo, DateTime dataNascimento, string role, DateTime dataCadastro, DateTime dataAtualizacaoCadastro)
    {
        this.Id = id;
        this.Name = name;
        this.Email = email;
        this.Password = password;
        this.Sexo = sexo;
        this.DataNascimento = dataNascimento;
        this.Role = role;
        this.DataCadastro = DateTime.Now;
        this.DataAtualizacaoCadastro = DateTime.Now;

    }
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public char Sexo { get; set; }

    [Required]
    public DateTime DataNascimento { get; set; }

    [Required]
    public string Role { get; set; } // Usar enum para os papéis    

    [Required]
    public DateTime DataCadastro { get; set; }

    public DateTime DataAtualizacaoCadastro { get; set; }


}
