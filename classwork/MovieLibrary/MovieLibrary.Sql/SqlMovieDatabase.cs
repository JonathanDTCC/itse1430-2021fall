// ITSE 1430
// Movie Library
// Jonathan Daniel
using System;
using System.Collections.Generic;
using System.Data;
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

        private SqlConnection OpenConnection ()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }

        protected override Movie AddCore ( Movie movie )
        {
            using (var conn = OpenConnection())
            {
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

                //Get movie ID as result
                object result = cmd.ExecuteScalar();
                movie.Id = Convert.ToInt32(result);

                //Don't do this Unneccesary when using using() {}
                //conn.close(); 
            };

            return movie;
        }

        protected override void DeleteCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("DeleteMovie", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            };
        }

        protected override Movie FindById ( int id ) => GetCore(id);

        protected override Movie FindByTitle ( string title )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("FindByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", title);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Movie() {
                            Id = Convert.ToInt32(reader[0]), //Ordinal and indexing
                            Title = Convert.ToString(reader["Name"]), //Name and indexing

                            Description = reader.IsDBNull(2) ? "" : reader.GetString(2), //Ordinal and Get
                            Rating = reader.GetString("Rating"), //Name and Get

                            ReleaseYear = reader.GetFieldValue<int>(4), //Ordinal and generic
                            RunLength = reader.GetFieldValue<int>("RunLength"), //Name and generic

                            IsClassic = reader.GetFieldValue<bool>("IsClassic"),
                        };
                    };
                };
            };

            return null;
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {
            //Buffered Reads
            // Dataset -> in memory representation
            var ds = new DataSet();

            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetMovies", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Load the data, connection must be open
                // 1. Must create adapter and associate with command
                // 2. Must create Dataset
                // 3. Call Fill on adapter
                var adapter = new SqlDataAdapter(cmd);

                ds = new DataSet();
                adapter.Fill(ds);
            };

            //Enumerate results
            // 1. Find the table
            // 2. Enumerate the rows
            // 3. Extract the data by ordinal or name
            // Have to use OfType<t> to convert from IEnumerable that dataset uses
            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
            {
                //foreach (DataRow row in table.Rows)
                foreach (var row in table.Rows.OfType<DataRow>())
                {
                    //Ordinal vs Name
                    // Ordinal - faster but tied to order of query
                    // Name - cleaner but slower
                    yield return new Movie() {
                        Id = Convert.ToInt32(row[0]), //Ordinal and indexing
                        Title = Convert.ToString(row["Name"]), //Name and indexing

                        Description = row.IsNull(2) ? "" : row.Field<string>(2), //Ordinal and generic
                        Rating = row.Field<string>("Rating"), //Name and generic

                        ReleaseYear = row.Field<int>("ReleaseYear"),
                        RunLength = row.Field<int>("RunLength"),
                        IsClassic = row.Field<bool>("IsClassic"),
                    };
                };
            };
        }

        protected override Movie GetCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetMovie", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                //Streamed
                // 'DataReader'
                // Forward only
                // Read only
                // Unstructed
                // -Fast-
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Movie() {
                            Id = Convert.ToInt32(reader[0]), //Ordinal and indexing
                            Title = Convert.ToString(reader["Name"]), //Name and indexing

                            Description = reader.IsDBNull(2) ? "" : reader.GetString(2), //Ordinal and Get
                            Rating = reader.GetString("Rating"), //Name and Get

                            ReleaseYear = reader.GetFieldValue<int>(4), //Ordinal and generic
                            RunLength = reader.GetFieldValue<int>("RunLength"), //Name and generic

                            IsClassic = reader.GetFieldValue<bool>("IsClassic"),
                        };
                    };
                };
            };

            return null;
        }

        protected override void UpdateCore ( int id, Movie movie )
        {

            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("UpdateMovie", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

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

                cmd.ExecuteNonQuery();
            };
        }
    }
}
