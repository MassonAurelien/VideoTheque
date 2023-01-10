﻿using Microsoft.AspNetCore.Mvc;
using VideoTheque.Businesses.Emprunts;
using VideoTheque.Constants;
using VideoTheque.ViewModels;

namespace VideoTheque.Controllers
{
    [ApiController]
    [Route("emprunts")]
    public class EmpruntsController : ControllerBase
    {
        private readonly IEmpruntsBusiness _empruntsBusiness;
        protected readonly ILogger<EmpruntsController> _logger;

        public EmpruntsController(ILogger<EmpruntsController> logger, IEmpruntsBusiness empruntsBusiness)
        {
            _logger = logger;
            _empruntsBusiness = empruntsBusiness;
        }

        [HttpGet]
        public async Task<List<MovieViewModel>> GetMovies() => (await _empruntsBusiness.GetFilms()).Select(c => new MovieViewModel
        {
            Id = c.Id,
            Director = c.Director,
            Scenarist = c.Scenarist,
            Duration = c.Duration,
            Support = EnumSupports.BluRays.ToString(),
            AgeRating = c.AgeRating,
            Genre = c.Genre,
            Title = c.Title,
            FirstActor = c.FirstActor
        }).ToList();
    }
}