using Microsoft.Data.SqlClient;

namespace CarsWithCheckBox.Models
{

    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public CarTypes CarType { get; set; }
        public bool HasLeatherSeats { get; set; }
    }



    public class CarsDb
    {
        private string _connectionString;

        public CarsDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Car> GetAllCars()
        {
            var connection = new SqlConnection(_connectionString);
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Cars";
            List<Car> cars = new();
            connection.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cars.Add(new()
                {
                    Id = (int)reader["Id"],
                    Make = (string)reader["Make"],
                    Model = (string)reader["Model"],
                    Year = (int)reader["Year"],
                    Price = (decimal)reader["Price"],
                    CarType = (CarTypes)reader["CarType"],
                    HasLeatherSeats = (bool)reader["HasLeatherSeats"]


                });
            }
            return cars;
        }

        public void AddCar(Car car)
        {
            var connection = new SqlConnection(_connectionString);
            var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO Cars (Make, Model, Year,Price ,CarType, HasLeatherSeats) " +
            "VALUES (@make, @model, @year, @price, @cartype ,@leatherseats)";
            cmd.Parameters.AddWithValue("@make", car.Make);
            cmd.Parameters.AddWithValue("@model", car.Model);
            cmd.Parameters.AddWithValue("@year", car.Year);
            cmd.Parameters.AddWithValue("@price", car.Price);
            cmd.Parameters.AddWithValue("@cartype", car.CarType);
            cmd.Parameters.AddWithValue("@leatherseats", car.HasLeatherSeats);
            connection.Open();
            cmd.ExecuteNonQuery();

        }


    }
}
