﻿using Microsoft.Build.Framework;

namespace FilmesApi.Data.Dto;

public class ReadEndereco
{   

    public int Id { get; set; }

    [Required]
    public string Logadouro { get; set; }
    
    public int Numero { get; set; }
}
