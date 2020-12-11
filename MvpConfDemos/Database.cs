using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MvpConfDemos
{
    public class Database
    {
        private readonly SqlConnection _connection;

        public Database()
        {
            var connectionString = @"SUA_CONNECTION_STRING_AQUI";
            _connection = new SqlConnection(connectionString);
        }

        public void Insert()
        {
            _connection.Open();

            for (int i = 0; i < 10_000_000; i++)
            {
                new SqlCommand($"INSERT INTO ClienteMvp (Nome, DataNascimento, ClienteEspecial, NomeDaMae, QuantidadeFilhos) VALUES ('Cliente {i}', GETDATE(), {i % 2}, 'Mae {i}', {i.ToString().Substring(0, 1)})", _connection).ExecuteNonQuery();
            }
        }

        public IEnumerable<Cliente> BuscarClientes()
        {
            var query = "SELECT * FROM ClienteMvp";
            var lstCliente = new List<Cliente>();

            _connection.Open();
            var cmd = new SqlCommand(query, _connection);
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    var time = new Stopwatch();
                    time.Start();

                    while (reader.Read())
                        lstCliente.Add(new Cliente
                        {
                            Id = (int)reader["Id"],
                            Nome = reader["Nome"].ToString(),
                            DataNascimento = (DateTime)reader["DataNascimento"],
                            ClienteEspecial = (bool)reader["ClienteEspecial"],
                            NomeDaMae = reader["NomeDaMae"].ToString(),
                            QuantidadeFilhos = (byte)reader["QuantidadeFilhos"]
                        });

                    time.Stop();
                    Console.WriteLine("Tempo buscando pelo nome da coluna: {0}", time.Elapsed);
                }
            }

            _connection.Close();

            return lstCliente;
        }

        public IEnumerable<Cliente> BuscarClientes2()
        {
            var query = "SELECT * FROM ClienteMvp";
            var lstCliente = new List<Cliente>();

            _connection.Open();
            var cmd = new SqlCommand(query, _connection);
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    var time = new Stopwatch();
                    time.Start();

                    int id = reader.GetOrdinal("Id"),
                        nome = reader.GetOrdinal("Nome"),
                        dataNascimento = reader.GetOrdinal("DataNascimento"),
                        clienteEspecial = reader.GetOrdinal("ClienteEspecial"),
                        nomeDaMae = reader.GetOrdinal("NomeDaMae"),
                        quantidadeFilhos = reader.GetOrdinal("QuantidadeFilhos");

                    while (reader.Read())
                        lstCliente.Add(new Cliente
                        {
                            Id = reader.GetInt32(id),
                            Nome = reader.GetString(nome),
                            DataNascimento = reader.GetDateTime(dataNascimento),
                            ClienteEspecial = reader.GetBoolean(clienteEspecial),
                            NomeDaMae = reader.GetString(nomeDaMae),
                            QuantidadeFilhos = reader.GetByte(quantidadeFilhos)
                        });

                    time.Stop();
                    Console.WriteLine("Tempo utilizando o GetOrdinal: {0}", time.Elapsed);
                }
            }

            _connection.Close();

            return lstCliente;
        }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool ClienteEspecial { get; set; }
        public string NomeDaMae { get; set; }
        public byte QuantidadeFilhos { get; set; }
    }
}
