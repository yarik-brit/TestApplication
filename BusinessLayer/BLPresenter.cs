using System.Collections.Generic;
using System.Linq;
using Data.Models;
using DBL = DatabaseLayer;

namespace BusinessLayer
{
    public class BLPresenter
    {
        public List<MovieModel> Movies { get; private set; }
        public List<DirectorModel> Directors { get; private set; }
        public List<GenreModel> Genres { get; private set; }

        DBL.DBLPresenter dblPresenter;

        public BLPresenter()
        {
            Movies = new List<MovieModel>();
            Directors = new List<DirectorModel>();
            Genres = new List<GenreModel>();

            dblPresenter = new();

            foreach (DirectorModel directorDb in dblPresenter.Directors)
            {
                Directors.Add(new DirectorModel
                {
                    DirectorId = directorDb.DirectorId,
                    Name = directorDb.Name,
                    Surname = directorDb.Surname
                });
            }

            foreach (GenreModel genreDb in dblPresenter.Genres)
            {
                Genres.Add(new GenreModel
                {
                    GenreId = genreDb.GenreId,
                    Name = genreDb.Name
                });
            }

            foreach (MovieModel movieDb in dblPresenter.Movies)
            {
                Movies.Add(new MovieModel
                {
                    Title = movieDb.Title,
                    MovieId = movieDb.MovieId,
                    DirectorId = movieDb.DirectorId,
                    GenreId = movieDb.GenreId,
                    Year = movieDb.Year
                });
            }
        }

        public object GetMeInnerJoin()
        {
            var movieGenre = Movies.Join(Genres,
                m => m.GenreId,
                g => g.GenreId,
                (m, g) => new
                {
                    Title = m.Title,
                    Year = m.Year,
                    Genre = g.Name
                });

            return movieGenre;
        }

        public object GetMeLeftJoin()
        {
            var movieDirector = (from m in Movies
                                join d in Directors
                                on m.DirectorId equals d.DirectorId into leftJoin
                                from d in leftJoin.DefaultIfEmpty()
                                select new
                                {
                                    MovieId = m.MovieId,
                                    MovieTitle = m.Title,
                                    DirectorId = d.DirectorId,
                                    DirectorName = d.Name + " " + d.Surname
                                }).ToList();

            return movieDirector;
        }

        public object GetMeUnion()
        {
            var moviesBefore2000 = Movies.Where(m => m.Year < 2000).OrderBy(m => m.Year);
            var moviesAfter2000 = Movies.Where(m => m.Year >= 2000).OrderBy(m => m.Year);

            IEnumerable<MovieModel> allMovies = moviesBefore2000.Union(moviesAfter2000).ToList();

            return allMovies;
        }
    }
}
