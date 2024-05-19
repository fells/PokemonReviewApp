using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using System.Xml.Linq;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository  // Created a public class which inherites from the Interface Repository
    {
        private readonly ConnectionContext _connectionContext;  // Created a private readonly Instance of the DatabaseContext
        public PokemonRepository(ConnectionContext context)   // Created a constructor that receives a ConnectionContext parameter
        {
            this._connectionContext = context;
        }

        public Pokemon GetPokemon(int id)
        {
            return _connectionContext.Pokemons.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _connectionContext.Pokemons.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var reviews = _connectionContext.Reviews.Where(p => p.Pokemon.Id == pokeId);

            if (reviews.Count() <= 0)
                return 0;

            return ((decimal)reviews.Sum(r => r.Rating) / reviews.Count());
        }

        public ICollection<Pokemon> GetPokemons()  // Implements the GetPokemons method from the IPokemonRepository
        {
            return _connectionContext.Pokemons.OrderBy(p => p.Id).ToList(); // Returns all of the data from the Pokemon Table and ordering by ID
        }

        public bool PokemonExists(int pokeId)
        {
            return _connectionContext.Pokemons.Any(p => p.Id == pokeId);
        }
    }
}
