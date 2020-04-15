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
