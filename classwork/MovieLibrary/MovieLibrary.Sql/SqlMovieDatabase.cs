// ITSE 1430
// Movie Library
// Jonathan Daniel
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MovieLibrary.Sql
{
    /// <summary>Provides a SQL Server implementation of <see cref="IMovieDatabase"/>.</summary>
    public class SqlMovieDatabase : MovieDatabase
    {
        public SqlMovieDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }

        //conn string -> Server, Database, Credentials
        private readonly string _connectionString;
        protected override Movie AddCore ( Movie movie )
        {
            var conn = OpenConnection();

            //C create (data) -> id "1 piece"
            //R read          -> rows
            //U udpdate (data)->
            //D delete  (data)->

            //Never concatenated for SqlCommand
            //Vulnerable to Sql Injection attack
            //Use parameters only
            //var badCommand = new SqlCommand("UPDATE Movie SET name = '"  + userInput + "'");

            var cmd = new SqlCommand("AddMovie", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //Add parameters, approach 1
            var parmName = new SqlParameter("@name", System.Data.SqlDbType.VarChar) {
                Value = movie.Title
            };
            cmd.Parameters.Add(parmName);

            //Approach 2
            var parmRating = cmd.CreateParameter();
            parmRating.ParameterName = "@rating";
            parmRating.SqlDbType = System.Data.SqlDbType.VarChar;
            parmRating.Value = movie.Rating;
            cmd.Parameters.Add(parmRating);

            //Approach 3 (SQL Server)
            cmd.Parameters.AddWithValue("@description", movie.Description);
            cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
            cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
            cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);

            object result = cmd.ExecuteScalar();

            return movie;
        }
        protected override void DeleteCore ( int id ) => throw new NotImplementedException();
        protected override Movie FindById ( int id ) => GetCore(id);
        protected override Movie FindByTitle ( string title ) => null;
        protected override IEnumerable<Movie> GetAllCore () => Enumerable.Empty<Movie>();
        protected override Movie GetCore ( int id ) => null;
        protected override void UpdateCore ( int id, Movie Movie ) => throw new NotImplementedException();

        private SqlConnection OpenConnection ()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }
    }
}
