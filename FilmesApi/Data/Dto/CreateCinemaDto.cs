using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dto;

public class CreateCinemaDto
{
    [Required]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "O campo precisa ser preenchido")]
    public string Nome { get; set;}
}
