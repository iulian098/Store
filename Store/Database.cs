using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Store
{
    class Database
    {
        MySqlConnection connection;

        private string server;
        private string database;
        private string user;
        private string password;

        #region Database connection

        public Database()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            database = "store";
            user = "user";
            password = "123456";

            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                                database + ";" + "UID=" + user + ";" + "PWD=" + password + ";PORT=3306";

            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {

                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;

            }
        }

        private bool CloseConnection()
        {

            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        #endregion

        #region Login/Register

        public void Register(string username, string password, string email, string address){

            string query = "INSERT INTO users (username, password, email, address) VALUES('" + username + "', '" + password + "', '" + email + "', '" + address + "')";

            if (checkUsername(username, email))
            {

                //open connection
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.ExecuteNonQuery();

                    this.CloseConnection();
                }

            }

        }

        public bool Login(string username, string password)
        {
            string pwd="";

            string query = "SELECT * FROM users WHERE username='" + username + "'";

            if (checkUsername(username))
            {
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        pwd = reader["password"] + "";
                    }

                    reader.Close();

                    this.connection.Close();
                }
            }

            if(password == pwd)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool checkUsername(string username)
        {
            int count=0;
            string query = "SELECT COUNT(*) FROM users WHERE username='" + username + "'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                count = int.Parse(cmd.ExecuteScalar() + "");

                this.CloseConnection();

            }
            
            if(count == 0)
            {
                MessageBox.Show("Username does not exist");
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool checkUsername(string username, string email)
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM users WHERE username='" + username + "'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                count = int.Parse(cmd.ExecuteScalar() + "");

                if (count != 0)
                {
                    DuplicateUsername();
                    return false;
                }

                query = "SELECT COUNT(*) FROM users WHERE email='" + email + "'";
                cmd = new MySqlCommand(query, connection);
                count = int.Parse(cmd.ExecuteScalar() + "");

                if (count != 0)
                {
                    DuplicateUsername();
                    return false;
                }

                this.CloseConnection();

                return true;

            }

            return false;
        }

        void DuplicateUsername()
        {
            MessageBox.Show("Username/Email already exist");
            this.CloseConnection();
        }

        #endregion

        #region GetItems

        public List<string>[] GetItems()
        {
            string query = "SELECT * from items";

            List<string>[] items = new List<string>[5];
            items[0] = new List<string>();
            items[1] = new List<string>();
            items[2] = new List<string>();
            items[3] = new List<string>();
            items[4] = new List<string>();


            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    items[0].Add(reader["id"] + "");
                    items[1].Add(reader["name"] + "");
                    items[2].Add(reader["price"] + "");
                    items[3].Add(reader["image"] + "");
                    items[4].Add(reader["quantity"] + "");
                }

                reader.Close();

                cmd.ExecuteNonQuery();

                this.CloseConnection();

                return items;
            }
            else
            {
                return items;
            }
        }
    }

    #endregion
}
