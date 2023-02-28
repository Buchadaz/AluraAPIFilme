using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dto
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "O campo precisa ser preenchido")]
        public string Nome { get; set; }
    }
}
