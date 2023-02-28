using System.ComponentModel.DataAnnotations;
namespace FilmesApi.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "O campo precisa ser preenchido")]
    public string Nome { get; set; }
}
