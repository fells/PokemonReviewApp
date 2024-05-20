using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ConnectionContext _reviewcontext;
        private readonly IMapper _mapper;

        public ReviewRepository(ConnectionContext context, IMapper mapper)
        {
            _reviewcontext = context;
            _mapper = mapper;
        }
        public ICollection<Review> GetReviews()
        {
            return _reviewcontext.Reviews.OrderBy(review => review.Id).ToList();
        }

        public Review GetReview(int reviewId)
        {
            return _reviewcontext.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();
        }


        public ICollection<Review> GetReviewsOfAPokemon(int pokeId)
        {
            return _reviewcontext.Reviews.Where(r => r.Pokemon.Id == pokeId).ToList();
        }

        public bool ReviewExists(int reviewId)
        {
            return _reviewcontext.Reviews.Any(r => r.Id == reviewId);
        }
    }
}
