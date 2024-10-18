
using System.Data.SqlClient;
using MODELSdb;

namespace DATALAYERdb
{
    public class OwnerData
    {
        string connectionString = "Data Source=LAPTOP-JGL8F6OD\\SQLEXPRESS;Initial Catalog=AccountManagement;Integrated Security=True;";
        SqlConnection sqlConnection;

        public OwnerData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<OwnerContent> GetUsers()
        {
            string getuser = "SELECT username, password FROM Account";
            SqlCommand select = new SqlCommand(getuser, sqlConnection);
            sqlConnection.Open();
            List<OwnerContent> userList = new List<OwnerContent>();

            SqlDataReader reader = select.ExecuteReader();

            while (reader.Read())
            {
                OwnerContent user = new OwnerContent
                {
                    username = reader["username"].ToString(),
                    password = reader["password"].ToString()
                };
                userList.Add(user);
            }
            sqlConnection.Close();
            return userList;
        }


        public int AddnewUser(string username, string password)
        {
            string addani = "INSERT INTO Account (username, password) VALUES (@username, @password)";
            SqlCommand addnewuser = new SqlCommand(addani, sqlConnection);

            addnewuser.Parameters.AddWithValue("@username", username);
            addnewuser.Parameters.AddWithValue("@password", password);

            sqlConnection.Open();

            int success = addnewuser.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int RemoveUser(string username)
        {
            string remove = "DELETE FROM Account WHERE username = @username";
            SqlCommand removeolduser = new SqlCommand(remove, sqlConnection);
            removeolduser.Parameters.AddWithValue("@username", username);

            sqlConnection.Open();

            int olduser = removeolduser.ExecuteNonQuery();

            sqlConnection.Close();

            return olduser;
        }

        public int UpdateAUser(string username, string password)
        {
            string update = "UPDATE Account SET password = @password WHERE username = @username";
            SqlCommand updateolduser = new SqlCommand(update, sqlConnection);

            updateolduser.Parameters.AddWithValue("@username", username);
            updateolduser.Parameters.AddWithValue("@password", password);


            sqlConnection.Open();

            int success = updateolduser.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }
    }
}
