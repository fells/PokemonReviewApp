using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository  // Created a public class which inherites from the Interface Repository
    {
        private readonly ConnectionContext _connectionContext;  // Created a private readonly Instance of the DatabaseContext
        public PokemonRepository(ConnectionContext context)   // Created a constructor that receives a ConnectionContext parameter
        {
            this._connectionContext = context;
        }

        public ICollection<Pokemon> GetPokemons()  // Implements the GetPokemons method from the IPokemonRepository
        {
            return _connectionContext.Pokemons.OrderBy(p => p.Id).ToList(); // Returns all of the data from the Pokemon Table and ordering by ID
        }
    }
}
