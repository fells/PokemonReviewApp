using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private ConnectionContext _connectionContext;

        public OwnerRepository(ConnectionContext context)
        {
            _connectionContext = context;
        }

        public ICollection<Owner> GetOwners()
        {
           return _connectionContext.Owners.ToList();
        }
        public Owner GetOwner(int ownerId)
        {
            return _connectionContext.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerOfAPokemon(int pokeId)
        {
            return _connectionContext.PokemonOwners.Where(p => p.Pokemon.Id == pokeId).Select(o => o.Owner).ToList();
        }


        public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
        {
            return _connectionContext.PokemonOwners.Where(p => p.Owner.Id == ownerId).Select(p => p.Pokemon).ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return _connectionContext.Owners.Any(o => o.Id == ownerId);
        }
    }
}
