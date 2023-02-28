using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dto;

public class CreateEndereco
{

    [Required]
    public string Logadouro { get; set; }

    [Required]
    public int Numero { get; set; }
}
