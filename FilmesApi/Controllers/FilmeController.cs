using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dto;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

//Criando as anotações
[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase // Herdando do ControllerBase
{
    /*private static List<Filme> filmes = new List<Filme>(); // Criando uma lista para adicionar os filmes
    private static int id = 0; */

    private FilmContext _context; // Injeção de dependência
    private IMapper _mapper;
    public FilmeController(FilmContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>

    [HttpPost]
    public IActionResult AdicionarFilme([FromBody] CreateFilmDto filmeDto) //Criando método para cadastrar o filme e explicitando que as informações

    {
        /*filme.Id = id++; //Recurso de incremento dos filmes organizados
        filmes.Add(filme); //Adicionando os filmes a lista*/
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges(); // Salvar no banco de dados
        return CreatedAtAction(nameof(LeituraFilmesPorId), //Retorna 201, item adicionado com sucesso.
            new { id = filme.Id },
            filme);

    }

    /// <summary>
    /// Trás as informações dos filmes
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>

    [HttpGet]
    public IEnumerable<ReadFilmeDto> LeituraFilme([FromQuery] int skip = 0,
    [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));
    }


    /// <summary>
    /// Trás as informações do filme específico (id)
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpGet("{id}")]
    public IActionResult LeituraFilmesPorId(int id)
    {
        var filme = _context.Filmes
            .FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);
    }


    /// <summary>
    /// Atualiza todos os parâmetros de um filme específico (id)
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id,
    [FromBody] UpdateFilmDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id);
        if (filme == null) return NotFound();
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }


    /// <summary>
    /// Atualiza parâmetros específicos de um filme específico (id)
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id);
        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmDto>(filme);
        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return NotFound();
        }


        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }


    /// <summary>
    /// Deleta um filme específico (id)
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id);
        if (filme == null) return NotFound();
        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
}

