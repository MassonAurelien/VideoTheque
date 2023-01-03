using VideoTheque.Core;
using VideoTheque.DTOs;
using VideoTheque.Repositories.Age_Rating;
using VideoTheque.Repositories.Genres;
using VideoTheque.Repositories.Movies;
using VideoTheque.Repositories.Personnes;
using VideoTheque.Repositories.Hosts;

namespace VideoTheque.Businesses.Movies
{
    public class MoviesBusiness : IMoviesBusiness
    {

        private readonly IMoviesRepository _moviesDao;
        private readonly IPersonnesRepository _personnesDao;
        private readonly IGenresRepository _genresDao;
        private readonly IAgeRatingRepository _ageRatingDao;
        private readonly IHostsRepository _hostsDao;

        public MoviesBusiness(IMoviesRepository moviesDao, IPersonnesRepository personnesDao, IGenresRepository genresDao, IAgeRatingRepository ageRatingDao, IHostsRepository hostDao)
        {
            _moviesDao = moviesDao;
            _personnesDao = personnesDao;
            _genresDao = genresDao;
            _ageRatingDao = ageRatingDao;
            _hostsDao = hostDao;
        }

        public async Task<List<FilmDto>> GetMovies()
        {
            List<FilmDto> films = new List<FilmDto>();
            var brs = await _moviesDao.GetMovies();
            foreach (BluRayDto film in brs)
            {
                var scenarist = await _personnesDao.GetPersonne(film.IdScenarist);
                var acteur = await _personnesDao.GetPersonne(film.IdFirstActor);
                var directeur = await _personnesDao.GetPersonne(film.IdDirector);
                var genre = await _genresDao.GetGenre(film.IdGenre);
                var ageRating = await _ageRatingDao.GetAgeRating(film.IdAgeRating);

                films.Add(new FilmDto(film, acteur.FirstName + ' ' + acteur.LastName, directeur.FirstName + ' ' + directeur.LastName, scenarist.FirstName + ' ' + scenarist.LastName, genre.Name, ageRating.Name));
            }
            return films;
        }

        public async Task<List<FilmDto>> GetMovies(int idPartenaire)
        {
            List<FilmDto> films = new List<FilmDto>();
            HttpClient client = new HttpClient();
            HostDto host = await _hostsDao.GetHost(idPartenaire);
            String path = host.Url + "/emprunts";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                films = await response.Content.ReadFromJsonAsync<List<FilmDto>>();
            }
            return films;
        }



        public async Task<FilmDto> GetMovie(int id)
        {
            var movie = _moviesDao.GetMovie(id).Result;

            if (movie == null)
            {
                throw new NotFoundException($"Movies '{id}' non trouvé");
            }
            var scenarist = await _personnesDao.GetPersonne(movie.IdScenarist);
            var acteur = await _personnesDao.GetPersonne(movie.IdFirstActor);
            var directeur = await _personnesDao.GetPersonne(movie.IdDirector);
            var genre = await _genresDao.GetGenre(movie.IdGenre);
            var ageRating = await _ageRatingDao.GetAgeRating(movie.IdAgeRating);
            var filmDto = new FilmDto(movie, acteur.FirstName + ' ' + acteur.LastName, directeur.FirstName + ' ' + directeur.LastName, scenarist.FirstName + ' ' + scenarist.LastName, genre.Name, ageRating.Name);
            return filmDto;
        }

        public async Task<FilmDto> GetMovie(int id, int partenaire)
        {
            HttpClient client = new HttpClient();
            HostDto host = await _hostsDao.GetHost(partenaire);
            String path = host.Url + "/emprunts/" + id;
            HttpResponseMessage response = await client.PostAsync(path, null);
            response.EnsureSuccessStatusCode();
            return null;
        }

        public FilmDto InsertMovie(FilmDto movie)
        {

            int genreId = FindGenre(movie.Genre).Result;
            int scenarist = FindPersonnage(movie.Scenarist).Result;
            int acteur = FindPersonnage(movie.FirstActor).Result;
            int directeur = FindPersonnage(movie.Director).Result;
            int ageRating = FindAgeRating(movie.AgeRating).Result;

            BluRayDto bluRayDto = new BluRayDto();
            bluRayDto.Duration = movie.Duration;
            bluRayDto.IdDirector = directeur;
            bluRayDto.Title = movie.Title;
            bluRayDto.IdGenre = genreId;
            bluRayDto.IdAgeRating = ageRating;
            bluRayDto.IdFirstActor = acteur;
            bluRayDto.IdScenarist = scenarist;
            if (genreId == -1 || scenarist == -1 || acteur == -1 || directeur == -1 || ageRating == -1)
            {
                throw new InternalErrorException($"Erreur lors de l'insertion du movie {movie.Title}. Argument inconnu");
            }

            if (_moviesDao.InsertMovie(bluRayDto).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de l'insertion du movie {movie.Title}");
            }

            return movie;
        }

        public void UpdateMovie(int id, FilmDto movie)
        {
            int genreId = FindGenre(movie.Genre).Result;
            int scenarist = FindPersonnage(movie.Scenarist).Result;
            int acteur = FindPersonnage(movie.FirstActor).Result;
            int directeur = FindPersonnage(movie.Director).Result;
            int ageRating = FindAgeRating(movie.AgeRating).Result;

            BluRayDto bluRayDto = new BluRayDto();
            bluRayDto.Duration = movie.Duration;
            bluRayDto.IdDirector = directeur;
            bluRayDto.Title = movie.Title;
            bluRayDto.IdGenre = genreId;
            bluRayDto.IdAgeRating = ageRating;
            bluRayDto.IdFirstActor = acteur;
            bluRayDto.IdScenarist = scenarist;

            if (genreId == -1 || scenarist == -1 || acteur == -1 || directeur == -1 || ageRating == -1)
            {
                throw new InternalErrorException($"Erreur lors de l'insertion du movie {movie.Title}. Argument inconnu");
            }


            if (_moviesDao.UpdateMovie(id, bluRayDto).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la modification de l'host {movie.Title}");
            }
        }

        public void DeleteMovie(int id)
        {
            if (_moviesDao.DeleteMovie(id).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la suppression du movie : {id}");
            }
        }

        private async Task<int> FindGenre(string name)
        {
            List<GenreDto> genres = await _genresDao.GetGenres();
            foreach (GenreDto genre in genres)
            {
                if (genre.Name.Equals(name)) return genre.Id;
            }
            return -1;
        }

        private async Task<int> FindAgeRating(string name)
        {
            List<AgeRatingDto> ages = await _ageRatingDao.GetAgeRatings();
            foreach (AgeRatingDto age in ages)
            {
                if (age.Name.Equals(name)) return age.Id;
                else if (age.Abreviation.Equals(name)) return age.Id;
            }
            return -1;
        }

        private async Task<int> FindPersonnage(string name)
        {
            List<PersonneDto> personnages = await _personnesDao.GetPersonnes();
            var firstName = name.Split(' ')[0];
            var surname = name.Split(' ')[1];
            foreach (PersonneDto personnage in personnages)
            {
                if (personnage.FirstName.Equals(firstName) && personnage.LastName.Equals(surname)) return personnage.Id;
            }
            return -1;
        }
    }
}
