using System.ComponentModel.DataAnnotations;

public class Usuario
{
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
