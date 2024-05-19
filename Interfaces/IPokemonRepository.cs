using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IPokemonRepository    //Creating a public Interface called IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();   // Creating a Method called GetPokemons that will return a list of data 

        Pokemon GetPokemon (int id);
        Pokemon GetPokemon(string name);
        decimal GetPokemonRating(int pokeId);
        bool PokemonExists(int pokeId);
    }   
}
