using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly ConnectionContext _reviewerContext;
        private readonly IMapper _mapper;

        public ReviewerRepository(ConnectionContext context, IMapper mapper)
        {
            _reviewerContext = context;
            _mapper = mapper;
        }


        public ICollection<Reviewer> GetReviewers()
        {
            return _reviewerContext.Reviewers.ToList(); 
        }

        public Reviewer GetReviewer(int reviewerId)
        {
            return _reviewerContext.Reviewers.Where(r => r.Id == reviewerId).Include(e => e.Reviews).FirstOrDefault();
        }


        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            return _reviewerContext.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
        }

        public bool ReviewerExists(int reviewerId)
        {
            return _reviewerContext.Reviewers.Any(r => r.Id == reviewerId);
        }
    }
}
