﻿using MySql.Data.MySqlClient;


namespace CSharpAndSQL.dal
{
    internal static class DBConnection
    {

        public static MySqlConnection Connect(string? cs = null)
        {
            var connStr = string.IsNullOrWhiteSpace(cs)
                ? "server=localhost;uid=root;password=;database=eagleeyedb"
                : cs;


            var conn = new MySqlConnection(connStr);
            conn.Open();
            return conn;
        }


        public static void Disconnect(MySqlConnection conn) => conn.Close();


        public static MySqlCommand Command(string sql)
        {
            var cmd = new MySqlCommand { CommandText = sql };
            return cmd;
        }


        public static MySqlDataReader Send(MySqlConnection conn, MySqlCommand cmd)
        {
            cmd.Connection = conn;
            return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }


        public static List<Dictionary<string, object?>> Parse(MySqlDataReader rdr)
        {
            var rows = new List<Dictionary<string, object?>>();


            using (rdr)
            {
                while (rdr.Read())
                {
                    var row = new Dictionary<string, object?>(rdr.FieldCount);
                    for (int i = 0; i < rdr.FieldCount; i++)
                        row[rdr.GetName(i)] = rdr.IsDBNull(i) ? null : rdr.GetValue(i);


                    rows.Add(row);
                }
            }
            return rows;
        }


        public static List<Dictionary<string, object?>> Execute(
            string sql,
            string? connectionString = null)
        {
            var conn = Connect(connectionString);
            var cmd = Command(sql);
            var rdr = Send(conn, cmd);
            return Parse(rdr);
        }


        public static void PrintResult(List<Dictionary<string, object?>> keyValuePairs)
        {
            if (keyValuePairs.Count == 0)
            {
                Console.WriteLine("No results found.");
                return;
            }


            foreach (var row in keyValuePairs)
            {
                foreach (var kv in row)
                    Console.WriteLine($"{kv.Key}: {kv.Value}");
                Console.WriteLine("---");
            }
        }
    }
}






