using Microsoft.EntityFrameworkCore;
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

        public Country GetCountry(int id)
        {
            return _connectionContext.Countries.Where(c => c.Id == id).FirstOrDefault();
        }
        
        public Country GetCountryByOwner(int ownerId)
        {
            return _connectionContext.Owners.Where(o => o.Id == ownerId).Select(c => c.Country).FirstOrDefault();
        }


        public ICollection<Owner> GetOwnersFromACountry(int countryId)
        {
            return _connectionContext.Owners.Where(c => c.Country.Id == countryId).ToList();
        }

        public bool CountryExists(int id)
        {
            return _connectionContext.Countries.Any(c => c.Id == id);
        }
    }
}
