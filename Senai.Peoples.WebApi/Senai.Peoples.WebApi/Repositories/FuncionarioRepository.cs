using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private string stringConexao = "Data Source = N-1S-DEV-05\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132";


        public void AtualizarIdCorpo(FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryUpdate = "UPDATE Funcionario SET Nome = @Nome WHERE IdFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", funcionario.IdFuncionario);
                    cmd.Parameters.AddWithValue("Nome", funcionario.Nome);


                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, FuncionarioDomain funcionario)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryUpdate = "UPDATE Funcionario SET Nome = @Nome WHERE IdFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);

                    con.Open();


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FuncionarioDomain BuscarPorId(int id)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT IdFuncionario, Nome FROM Funcionario WHERE IdFuncionario = @ID";


                con.Open();


                SqlDataReader rdr;


                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);


                    rdr = cmd.ExecuteReader();


                    if (rdr.Read())
                    {

                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {

                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"])

                            ,
                            Nome = rdr["Nome"].ToString()
                        };


                        return funcionario;
                    }


                    return null;
                }
            }
        }

        public void Cadastrar(FuncionarioDomain funcionario)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryInsert = "INSERT INTO Funcionario(Nome) VALUES (@Nome)";


                SqlCommand cmd = new SqlCommand(queryInsert, con);


                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryDelete = "DELETE FROM Funcionario WHERE IdFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);


                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<FuncionarioDomain> Listar()
        {

            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdFuncionario, Nome from Funcionario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),

                            Nome = rdr["Nome"].ToString()
                        };

                        funcionarios.Add(funcionario);
                    }
                }
            }

            return funcionarios;
        }
    }
}
