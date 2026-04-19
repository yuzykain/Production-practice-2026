using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using MySqlConnector;


namespace AutoPodbor
{
    internal class Account
    {
        private static string connStr = "server=localhost;user=Dima;database=autoPodbor;password=1;";
        public static bool Registration(string login,string pass,string passConf)
        {
            List<string> logins = new List<string>();
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT login FROM accounts";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                logins.Add(reader[0].ToString());
            }
            conn.Close();
            if (pass != passConf || login.Length <=5 || pass.Length<7 || logins.Contains(login) || login.Contains("-"))
            {
                return false;
            }
            else 
            {
                conn.Open();
                string sql2 = $"INSERT INTO accounts VALUES('0','{login}','{GetHash(pass)}','{login}','0')";
                MySqlCommand command2 = new MySqlCommand(sql2, conn);
                command2.ExecuteNonQuery();
                conn.Close();
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                File.WriteAllText(Path.Combine(folderPath, "accountInfo"), login);
                return true;
            }
        }
        public static bool Authorization(string login, string pass)
        {
            try
            {
                string passSql = string.Empty;
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sql = $"SELECT * FROM accounts WHERE login ='{login}'";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    passSql = reader[2].ToString();
                }
                if (GetHash(pass) == passSql)
                {

                    string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    File.WriteAllText(Path.Combine(folderPath, "accountInfo"), login);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }


        }
        private static string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }
        public static void AddFavorite(string log,int car)
        {
            List<int> ids = new List<int>();
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sql2 = $"SELECT car_id FROM favorites WHERE login ='{log}'";
                MySqlCommand command2 = new MySqlCommand(sql2, conn);
                MySqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    ids.Add(Convert.ToInt32(reader2[0].ToString()));
                }
                conn.Close();
                if (!ids.Contains(car))
                {
                    conn.Open();
                    string sql = $"INSERT INTO favorites VALUES('0','{log}','{car}')";
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                new Exception("Error Network");
                Debug.Write("-------------------------------------------------------\n CATCH!!!!!!!!!!!!!!!!!" + ex.Message);
            }
        }
        public static List<Car> CheckFavorites(string log)
        {
            Car car = new Car();
            List<Car> listCars = new List<Car>();
            List<Car> cars = new List<Car>();
            cars = car.ReadCars(cars);
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sql2 = $"SELECT car_id FROM favorites WHERE login ='{log}' ORDER BY id DESC";
                MySqlCommand command2 = new MySqlCommand(sql2, conn);
                MySqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    listCars.Add(cars.FindAll(x=>x.Id == Convert.ToInt32(reader2[0].ToString()))[0]);
                }
                conn.Close();
                return listCars;
            }
            catch (Exception ex)
            {
                new Exception("Error Network");
                Debug.Write("-------------------------------------------------------\n CATCH!!!!!!!!!!!!!!!!!" + ex.Message);
                return listCars;
            }

        }
    }
}
