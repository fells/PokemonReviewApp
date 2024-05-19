using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CountryRepository : ICountryRepository
    {

        private ConnectionContext _connectionContext;

        public CountryRepository(ConnectionContext context)
        {
            _connectionContext = context;
        }
        public ICollection<Country> GetCountries()
        {
            return _connectionContext.Countries.OrderBy(c => c.Id).ToList();
        }
    }
}
