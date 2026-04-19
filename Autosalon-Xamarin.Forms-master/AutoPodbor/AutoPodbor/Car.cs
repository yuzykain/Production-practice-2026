using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;
namespace AutoPodbor
{
    public class Car
    {
        private int id;
        private string mark;
        private string description;
        private string model;
        private string generation;
        private int yearStart;
        private int yearEnd;
        private double price;
        private double engineVolume;
        private string transmission;
        private string body;
        private string engine;
        private string wheelDrive;
        private string urlImg;

        public Car()
        {
        }

        public Car(int id, string mark, string description, string model, string generation, int yearStart, int yearEnd, double price, double engineVolume, string transmission, string body, string engine, string wheelDrive, string urlImg)
        {
            this.id = id;
            this.mark = mark;
            this.description = description;
            this.model = model;
            this.generation = generation;
            this.yearStart = yearStart;
            this.yearEnd = yearEnd;
            this.price = price;
            this.engineVolume = engineVolume;
            this.transmission = transmission;
            this.body = body;
            this.engine = engine;
            this.wheelDrive = wheelDrive;
            this.urlImg = urlImg;
        }
        public int Id 
        {
            get => this.id;
            set => this.id = value;
        }
        public string Mark 
        { 
            get => this.mark;
            set => this.mark = value;
        }
        public string Description
        { 
            get=>this.description;
            set => this.description = value;
        }
        public string Model
        {
            get => this.model;
            set => this.model = value;
        }
        public string Generation
        {
            get => this.generation;
            set=> this.generation = value;
        }
        public int YearStart
        { 
            get => this.yearStart;
            set => this.yearStart = value;
        }
        public int YearEnd
        { 
            get => this.yearEnd;
            set => this.yearEnd = value;
        }
        public double Price
        {
            get => this.price;
            set => this.price = value;
        }
        
        public double EngineVolume
        { 
            get => this.engineVolume; 
            set => this.engineVolume = value;
        }
        public string Transmission
        {
            get => this.transmission;
            set => this.transmission = value;
        }
        public string Body
        {
            get => this.body;
            set => this.body = value;
        }
        public string Engine
        {
            get => this.engine;
            set => this.engine = value;
        }
        public string WheelDrive
        {
            get => this.wheelDrive;
            set => this.wheelDrive = value;
        }
        public string UrlImg
        { 
            get=>this.urlImg;
            set => this.urlImg = value;
        }

        public List<Car> ReadCars(List<Car> cars)
        {
            try
            {
                string connStr = "server=localhost;user=Dima;database=autoPodbor;password=1;";
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sql = "SELECT * FROM cars";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cars.Add(new Car(
                        Convert.ToInt32(reader[0].ToString()),
                        reader[1].ToString(),
                        reader[3].ToString(),
                        reader[2].ToString(),
                        reader[4].ToString(),
                        Convert.ToInt32(reader[5].ToString()),
                        Convert.ToInt32(reader[6].ToString()),
                        Convert.ToDouble(reader[7].ToString()),
                        Convert.ToDouble(reader[8].ToString()),
                        reader[9].ToString(),
                        reader[10].ToString(),
                        reader[11].ToString(),
                        reader[12].ToString(),
                        $"http://194.87.210.23/images/{reader[13].ToString()}.jpg"
                    ));
                }
                reader.Close();
                conn.Close();
                return cars;
            }
            catch (Exception ex)
            {
                return cars;   
            }


        }
        

    }

}
