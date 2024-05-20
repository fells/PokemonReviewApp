using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countriesRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countriesRepository, IMapper mapper)
        {
            this._countriesRepository = countriesRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CountryDto>>(_countriesRepository.GetCountries());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categories);
        }



        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]

        public IActionResult GetCategory(int countryId)
        {
            if (!_countriesRepository.CountryExists(countryId))
                return NotFound();

            var country = _mapper.Map<CountryDto>(_countriesRepository.GetCountry(countryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(country);
        }



        [HttpGet("owners/{countryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        [ProducesResponseType(400)]

        public IActionResult GetPokemonByCategory(int countryId)
        {

            var country = _mapper.Map<CountryDto>(
                _countriesRepository.GetCountryByOwner(countryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(country);
        }

    }
}
