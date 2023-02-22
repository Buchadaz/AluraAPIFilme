using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data
{
    public class FilmContext : DbContext // Herdando do DbContext 
    {
        public FilmContext(DbContextOptions<FilmContext> opts) : base(opts) // Opções de acessos do banco
        {

        }
        public DbSet<Filme> Filmes { get; set; }
    }
}
