using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dto;

public class CreateFilmDto
{
    [Required]
    [StringLength(100, ErrorMessage = "O campo precisa estar entre 3 e 100 caracteres", MinimumLength = 3)]
    public string Titulo { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "O campo não pode exceder 100 caracteres", MinimumLength = 3)]
    public string Genero { get; set; }

    [Required]
    [Range(70, 200, ErrorMessage = "A duração deve ser entre 70 e 200 minutos")]
    public int Duracao { get; set; }
}
