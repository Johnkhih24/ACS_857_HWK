using MySql.Data.MySqlClient;

private static string connectionString = "server=<hostname>;port=<port>;user id=<username>;password=<password>;database=<database>";

private static void ConnectToMySQL()
{
    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        connection.Open();

        // Insert data
        string insertSql = "INSERT INTO table_name (column1, column2) VALUES (@value1, @value2)";
        using (MySqlCommand insertCommand = new MySqlCommand(insertSql, connection))
        {
            insertCommand.Parameters.AddWithValue("@value1", "data1");
            insertCommand.Parameters.AddWithValue("@value2", "data2");
            insertCommand.ExecuteNonQuery();
        }

        // Update data
        string updateSql = "UPDATE table_name SET column2 = @newValue WHERE column1 = @value1";
        using (MySqlCommand updateCommand = new MySqlCommand(updateSql, connection))
        {
            updateCommand.Parameters.AddWithValue("@newValue", "updatedData");
            updateCommand.Parameters.AddWithValue("@value1", "data1");
            updateCommand.ExecuteNonQuery();
        }

        // Retrieve data
        string selectSql = "SELECT * FROM table_name";
        using (MySqlCommand selectCommand = new MySqlCommand(selectSql, connection))
        {
            using (MySqlDataReader reader = selectCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("Column1: {0}, Column2: {1}", reader["column1"], reader["column2"]);
                }
            }
        }
    }
}
