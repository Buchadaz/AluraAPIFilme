using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dto;

public class CreateEnderecoDto
{

    [Required]
    public string Logadouro { get; set; }

    [Required]
    public int Numero { get; set; }
}
