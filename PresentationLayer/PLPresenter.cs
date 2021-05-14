using Data.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using BL = BusinessLayer;

namespace PresentationLayer
{
    public class PLPresenter
    {
        public List<MovieModel> Movies { get; private set; }
        public List<DirectorModel> Directors { get; private set; }
        public List<GenreModel> Genres { get; private set; }
        BL.BLPresenter blPresenter;

        public PLPresenter()
        {
            Movies = new List<MovieModel>();
            Directors = new List<DirectorModel>();
            Genres = new List<GenreModel>();

            blPresenter = new();

            foreach (DirectorModel director in blPresenter.Directors)
            {
                Directors.Add(new DirectorModel
                {
                    DirectorId = director.DirectorId,
                    Name = director.Name,
                    Surname = director.Surname
                });
            }

            foreach (GenreModel genre in blPresenter.Genres)
            {
                Genres.Add(new GenreModel
                {
                    GenreId = genre.GenreId,
                    Name = genre.Name
                });
            }

            foreach (MovieModel movie in blPresenter.Movies)
            {
                Movies.Add(new MovieModel
                {
                    Title = movie.Title,
                    DirectorId = movie.DirectorId,
                    GenreId = movie.GenreId,
                    Year = movie.Year
                });
            }
        }

        public void ShowAllLibrary()
        {
            var strLngth = (Total: 65, Large: 30, Big: 20, Medium: 10, Small: 5);
            var str = (Movie: "Movie", Director: "Director", Genre: "Genre", MovieId: "MovieId", DirectorId: "DirectorId", GenreId: "GenreId", Title: "Title", Year: "Year");
            Console.WriteLine("All movies list.");
            Console.WriteLine(str.Title + new string(' ', strLngth.Large - str.Title.Length - 1) + "|" + str.DirectorId + new string(' ', strLngth.Big - str.DirectorId.Length - 1) + "|" 
                + str.GenreId + new string(' ', strLngth.Medium - str.GenreId.Length - 1) + "|" + str.Year + new string(' ', strLngth.Small - str.Year.Length - 1));
            Console.WriteLine(new string('-', strLngth.Total));
            foreach(MovieModel m in Movies)
            {
                Console.Write(m.Title + new string(' ', strLngth.Large - m.Title.Length));
                Console.Write(m.DirectorId + new string(' ', strLngth.Big - m.DirectorId.ToString().Length));
                Console.Write(m.GenreId + new string(' ', strLngth.Medium - m.GenreId.ToString().Length));
                Console.Write(m.Year + new string(' ', strLngth.Small - m.Year.ToString().Length));
                Console.Write("\n");
            }

            Console.Write("\n\n");
            Console.WriteLine("All directors list.");
            Console.WriteLine(str.DirectorId + new string(' ', strLngth.Big - str.DirectorId.Length - 1) + "|"
                + str.Director + new string(' ', strLngth.Large - str.Director.Length - 1));
            Console.WriteLine(new string('-', strLngth.Total));
            foreach (DirectorModel d in Directors)
            {
                Console.Write(d.DirectorId + new string(' ', strLngth.Big - d.DirectorId.ToString().Length));
                Console.Write(d.Name + " " + d.Surname + new string(' ', strLngth.Large - d.Name.Length - d.Surname.Length));
                Console.Write("\n");
            }

            Console.Write("\n\n");
            Console.WriteLine("All genres list.");
            Console.WriteLine(str.GenreId + new string(' ', strLngth.Medium - str.GenreId.Length - 1) + "|"
                + str.Genre + new string(' ', strLngth.Medium - str.Genre.Length - 1));
            Console.WriteLine(new string('-', strLngth.Total));
            foreach (GenreModel g in Genres)
            {
                Console.Write(g.GenreId + new string(' ', strLngth.Medium - g.GenreId.ToString().Length));
                Console.Write(g.Name + new string(' ', strLngth.Medium - g.Name.Length));
                Console.Write("\n");
            }
        }

        public void DoTask()
        {
            Console.Write("\n\n");
            Console.WriteLine("Inner Join (innerjoined genres to movies where movie.genreId == genre.genreId):");
            Console.WriteLine(new string('-', 65));
            ShowInnerJoin();

            Console.Write("\n\n");
            Console.WriteLine("Left Join (leftjoined movies and directors):");
            Console.WriteLine(new string('-', 65));
            ShowLeftJoin();

            Console.Write("\n\n");
            Console.WriteLine("Union (movies splitted on two parts - before and after year 2000, sorted and unioned):");
            Console.WriteLine(new string('-', 65));
            ShowUnion();
        }

        public void ShowInnerJoin()
        {
            dynamic result = blPresenter.GetMeInnerJoin();
            foreach(var x in result)
            {
                Console.WriteLine(x);
            }
        }

        public void ShowLeftJoin()
        {
            dynamic result = blPresenter.GetMeLeftJoin();
            foreach (var x in result)
            {
                Console.WriteLine(x);
            }
        }

        public void ShowUnion()
        {
            dynamic result = blPresenter.GetMeUnion();
            foreach (var x in result)
            {
                Console.Write("{ Title = " + x.Title + ", MovieId = " + x.MovieId + ", DirectorId = " + x.DirectorId + ", GenreId = " + x.GenreId + ", Year = " + x.Year + "}\n");
            }
        }
    }
}
