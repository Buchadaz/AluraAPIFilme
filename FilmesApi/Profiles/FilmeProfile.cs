﻿using AutoMapper;
using FilmesApi.Data.Dto;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmDto, Filme>();
            CreateMap<UpdateFilmDto, Filme>();
            CreateMap<Filme, UpdateFilmDto>();
            CreateMap<Filme, ReadFilmeDto>();
        }
    }
}
