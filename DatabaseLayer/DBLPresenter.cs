using Dapper;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace DatabaseLayer
{
    public enum DbElementType
    {
        Movie = 0,
        Director = 1,
        Genre = 2
    }

    public class DBLPresenter
    {
        public List<MovieModel> Movies { get; private set; }
        public List<DirectorModel> Directors { get; private set; }
        public List<GenreModel> Genres { get; private set; }
        public string ConnectionString { get; private set; }

        public DBLPresenter()
        {
            LoadConnectionString();
            GetRawMoviesData();
            GetRawDirectorsData();
            GetRawGenresData();
        }

        private void LoadConnectionString(string name = "MyConnString")
        {
            ConnectionString = ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public void GetRawMoviesData()
        {
            using (IDbConnection cnn = new SQLiteConnection(ConnectionString))
            {
                Movies = cnn.Query<MovieModel>("SELECT * FROM Movie").AsList();
            }
        }
        public void GetRawDirectorsData()
        {
            using (IDbConnection cnn = new SQLiteConnection(ConnectionString))
            {
                Directors = cnn.Query<DirectorModel>("SELECT * FROM Director").AsList();
            }
        }
        public void GetRawGenresData()
        {
            using (IDbConnection cnn = new SQLiteConnection(ConnectionString))
            {
                Genres = cnn.Query<GenreModel>("SELECT * FROM Genre").AsList();
            }
        }

        public void AddElement(DbElementType type)
        {
            switch (type)
            {
                case DbElementType.Movie:
                    //logic for adding movie to db here
                    break;
                case DbElementType.Director:
                    //logic for adding director to db here
                    break;
                case DbElementType.Genre:
                    //logic for adding genre to db here
                    break;
                default:
                    throw new Exception("Unsupportable DbElementType!");
            }
            // after adding top-level locals should be refreshed
        }

        public void DeleteElement(DbElementType type)
        {
            switch (type)
            {
                case DbElementType.Movie:
                    //logic for deleting movie to db here
                    break;
                case DbElementType.Director:
                    //logic for deleting director to db here
                    break;
                case DbElementType.Genre:
                    //logic for deleting genre to db here
                    break;
                default:
                    throw new Exception("Unsupportable DbElementType!");
            }
            // after deleting top-level locals should be refreshed
        }

        //SAME FOR EDITING
    }
}
