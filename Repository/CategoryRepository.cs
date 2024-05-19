using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private ConnectionContext _connectionContext;

        public CategoryRepository(ConnectionContext context)
        {
            _connectionContext = context;
        }

        public ICollection<Category> GetCategories()  // Implements the GetPokemons method from the ICategoryRepository
        {
            return _connectionContext.Categories.OrderBy(p => p.Id).ToList(); // Returns all of the data from the Pokemon Table and ordering by ID
        }

        public Category GetCategory(int id)
        {
            return _connectionContext.Categories.Where(c => c.Id == id).FirstOrDefault();

        }

        ICollection<Pokemon> ICategoryRepository.GetPokemonByCategory(int categoryId)
        {
            return _connectionContext.PokemonCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
        }

        public bool CategoryExists(int id)
        {
            return _connectionContext.Categories.Any(c => c.Id == id);
        }
    }
}
