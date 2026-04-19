using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using MySqlConnector;


namespace AutoPodbor
{
    internal class Request
    {
        private int id;
        private int id_account;
        private int id_car;
        private string login;
        private string message;
        private int status;
        private string adminAnswer;
        private string date;
        private string listViewText;
        private static string connStr = "server=localhost;user=Dima;database=autoPodbor;password=1;";


        public Request(int id, int id_account, int id_car,string login,string message, int status, string adminAnswer,string date,string listViewText)
        {
            this.id = id;
            this.id_account = id_account;
            this.id_car = id_car;
            this.login = login;
            this.message = message;
            this.status = status;
            this.adminAnswer = adminAnswer;
            this.date = date;
            this.listViewText = listViewText;
        }
        public int Id { get => this.id; }
        public int Id_account { get => this.id_account; }
        public int Id_car { get => this.id_car; }
        public string Login { get => this.login; }
        public string Message { get => this.message;}
        public int Status { get => this.status;}
        public string AdminAnswer { get => this.adminAnswer;}
        public string ListViewText { get => this.listViewText;}
        public string Date { get => this.date; }
        public static List<Request> ReadRequests()
        {
            List<Request> requests = new List<Request>();
            try
            {
                
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sql = "SELECT * FROM requests";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    requests.Add(new Request(
                        Convert.ToInt32(reader[0].ToString()),
                        Convert.ToInt32(reader[1].ToString()),
                        Convert.ToInt32(reader[2].ToString()),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        Convert.ToInt32(reader[5].ToString()),
                        reader[6].ToString(),
                        reader[7].ToString(),
                        $"{reader[3].ToString()} - {reader[7].ToString()} - STATUS {reader[5].ToString()}"
                    ));
                }
                reader.Close();
                conn.Close();
            }
            catch {
                new Exception("Error Network");
            
            }
            return requests;
        }
        public static void WriteRequest(Request req)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sql = $"INSERT INTO requests VALUES('{req.id}','{req.id_account}','{req.id_car}','{req.login}','{req.message}','{req.status}','{req.adminAnswer}','{req.date}')";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                conn.Close();
            }
            catch(Exception ex)
            {
                new Exception("Error Network");
                Debug.Write("-------------------------------------------------------\n CATCH!!!!!!!!!!!!!!!!!" + ex.Message);

            }
        }
        public static void SetState(bool res, int id)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sql = string.Empty;
                if (res)
                    sql = $"UPDATE requests SET status = '1' WHERE id = '{id}' ";
                else
                    sql = $"UPDATE requests SET status = '2' WHERE id = '{id}' ";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                conn.Close();
                
            }
            catch (Exception ex)
            {
                new Exception("Error Network");
                Debug.Write("-------------------------------------------------------\n CATCH!!!!!!!!!!!!!!!!!" + ex.Message);
            }
        }
        public static List<Request> AccountRequests(string log)
        {
            List<Request> requests = new List<Request>();
            try
            {

                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sql = $"SELECT * FROM requests WHERE login = '{log}' ORDER BY id DESC";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    requests.Add(new Request(
                        Convert.ToInt32(reader[0].ToString()),
                        Convert.ToInt32(reader[1].ToString()),
                        Convert.ToInt32(reader[2].ToString()),
                        reader[3].ToString(),
                        reader[4].ToString(),
                        Convert.ToInt32(reader[5].ToString()),
                        reader[6].ToString(),
                        reader[7].ToString(),
                        $"{reader[3].ToString()} - {reader[7].ToString()} - STATUS {((Convert.ToInt32(reader[5].ToString()) == 1) ? (Convert.ToInt32(reader[5].ToString()) == 2)? "Отклонено" : "Одобрено" : "На рассмотрении")}" 
                    ));
                }
                reader.Close();
                conn.Close();
            }
            catch
            {
                new Exception("-----------------------------------------------\nError Network");

            }
            return requests;
        }
    }
}
