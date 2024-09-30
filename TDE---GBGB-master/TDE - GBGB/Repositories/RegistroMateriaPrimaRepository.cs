using MySql.Data.MySqlClient;
using System.Data;
using TDE___GBGB.Models;

namespace TDE___GBGB.Repositories
{
    public class RegistroMateriaPrimaRepository : IRegistroMateriaPrimaRepository
    {
        #region conexão
        private readonly string _connectionString;

        // Construtor da classe UsuarioRepository que recebe IConfiguration
        public RegistroMateriaPrimaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new ArgumentException("Connection string is null or empty");
            }
        }

        // Método privado para obter a conexão com o banco de dados
        private IDbConnection GetConnection()
        {
            // Retorna uma nova conexão MySqlConnection utilizando a _connectionString definida no construtor
            return new MySqlConnection(_connectionString);
        }
        #endregion

        public List<RegistroMateriaPrimaModel> ListaRegistrosMateriaPrima()
        {
            List<RegistroMateriaPrimaModel> Registros = new List<RegistroMateriaPrimaModel>();

            using (var connection = GetConnection())
            {
                string query = @"SELECT 
                            R.ID_REGISTRO,
                            R.ID_MATERIA_PRIMA,
                            R.ID_PRODUTO,
                            R.ID_FORNECEDOR,
                            R.ID_USUARIO_RESPONSAVEL,
                            R.QUANTIDADE_KG,
                            R.DAT_PRODUCAO,
                            R.DAT_LOTE,
                            R.DAT_REGISTRO
                         FROM REGISTRO_MATERIA_PRIMA R
                         WHERE R.IND_ATIVO = 1";

                using (var reader = connection.ExecuteReader(query))
                {
                    while (reader.Read())
                    {
                        RegistroMateriaPrimaModel registro = new RegistroMateriaPrimaModel
                        {
                            IdRegistro = reader.GetInt32(reader.GetOrdinal("ID_REGISTRO")),
                            IdMateriaPrima = reader.GetInt32(reader.GetOrdinal("ID_MATERIA_PRIMA")),
                            IdProduto = reader.GetInt32(reader.GetOrdinal("ID_PRODUTO")),
                            IdFornecedor = reader.GetInt32(reader.GetOrdinal("ID_FORNECEDOR")),
                            IdUsuario = reader.GetInt32(reader.GetOrdinal("ID_USUARIO_RESPONSAVEL")),
                            QuantidadeKG = reader["QUANTIDADE_KG"].ToDouble(),
                            DataProducao = reader["DAT_PRODUCAO"].ToDateTime(),
                            DataLote = reader["QUANTIDADE_KG"].ToDateTime(),
                            DataRegistro = reader["DAT_REGISTRO"].ToDateTime()
                        };
                        Registros.Add(registro);
                    }
                }

                return Registros;
            }
        }

        public RegistroMateriaPrimaModel ListaRegistroMateriaPrima(int id)
        {
            RegistroMateriaPrimaModel registro = null;

            using (var connection = GetConnection())
            {
                string query = @"SELECT
                                        R.ID_REGISTRO,
                                        R.ID_MATERIA_PRIMA,
                                        R.ID_PRODUTO,
                                        R.ID_FORNECEDOR,
                                        R.ID_USUARIO_RESPONSAVEL,
                                        R.QUANTIDADE_KG,
                                        R.DAT_PRODUCAO,
                                        R.DAT_LOTE,
                                        R.DAT_REGISTRO
                                       FROM REGISTRO_MATERIA_PRIMA R
                                       WHERE R.ID_REGISTRO = @Id";

                using (var reader = connection.ExecuteReader(query, new { Id = id }))
                {
                    while (reader.Read())
                    {
                        registro = new RegistroMateriaPrimaModel
                        {
                            IdRegistro = reader.GetInt32(reader.GetOrdinal("ID_REGISTRO")),
                            IdMateriaPrima = reader.GetInt32(reader.GetOrdinal("ID_MATERIA_PRIMA")),
                            IdProduto = reader.GetInt32(reader.GetOrdinal("ID_PRODUTO")),
                            IdFornecedor = reader.GetInt32(reader.GetOrdinal("ID_FORNECEDOR")),
                            IdUsuario = reader.GetInt32(reader.GetOrdinal("ID_USUARIO_RESPONSAVEL")),
                            QuantidadeKG = reader["QUANTIDADE_KG"].ToDouble(),
                            DataProducao = reader["DAT_PRODUCAO"].ToDateTime(),
                            DataLote = reader["QUANTIDADE_KG"].ToDateTime(),
                            DataRegistro = reader["DAT_REGISTRO"].ToDateTime()

                        };
                    }
                }
            }

            return registro;
        }

        public void AdicionaRegistroMateriaPrima(RegistroMateriaPrimaModel registro)
        {
            using (var connection = GetConnection())
            {
                string query = @"INSERT INTO REGISTRO_MATERIA_PRIMA (
                            ID_REGISTRO,
                            ID_MATERIA_PRIMA,
                            ID_PRODUTO,
                            ID_FORNECEDOR,
                            ID_USUARIO_RESPONSAVEL,
                            QUANTIDADE_KG,
                            DAT_PRODUCAO,
                            DAT_LOTE,
                            DAT_REGISTRO
                            )
                            VALUES (
                            @IdRegistro,
                            @IdMateriaPrima,
                            @IdProduto,
                            @IdFornecedor,
                            @IdUsuario,
                            @QuantidadeKG,
                            @DataProducao,
                            @DataLote,
                            @DataRegistro
                            )";

                connection.Execute(query, new
                {
                    IdRegistro = registro.IdRegistro,
                    IdMateriaPrima = registro.IdMateriaPrima,
                    IdProduto = registro.IdProduto,
                    IdFornecedor = registro.IdFornecedor,
                    IdUsuario = registro.IdUsuario,
                    QuantidadeKG = registro.QuantidadeKG,
                    DataProducao = registro.DataProducao,
                    DataLote = registro.DataLote,
                    DataRegistro = registro.DataRegistro,
                });
            }
        }


        public void EditaRegistroMateriaPrima(RegistroMateriaPrimaModel registro, int id)
        {
            using (var connection = GetConnection())
            {
                string query = @"
                    UPDATE REGISTRO_MATERIA_PRIMA
                    SET 
                        ID_MATERIA_PRIMA = @IdMateriaPrima,
                        ID_PRODUTO = @IdProduto,
                        ID_FORNECEDOR = @IdFornecedor,
                        ID_USUARIO_RESPONSAVEL = @IdUsuario,
                        QUANTIDADE_KG = @QuantidadeKG,
                        DAT_PRODUCAO = @DataProducao,
                        DAT_LOTE = @DataLote,
                        DAT_REGISTRO = @DataRegistro                        
                    WHERE ID_REGISTRO = @IdRegistroMateriaPrima";

                connection.Execute(query, new
                {
                    IdMateriaPrima = registro.IdMateriaPrima,
                    IdProduto = registro.IdProduto,
                    IdFornecedor = registro.IdFornecedor,
                    IdUsuario = registro.IdUsuario,
                    QuantidadeKG = registro.QuantidadeKG,
                    DataProducao = registro.DataProducao,
                    DataLote = registro.DataLote,
                    DataRegistro = registro.DataRegistro,
                    IdRegistroMateriaPrima = id
                });
            }
        }

        public void DeletaRegistroMateriaPrima(int id)
        {
            using (var connection = GetConnection())
            {
                string query = "UPDATE REGISTRO_MATERIA_PRIMA SET IND_ATIVO = 0 WHERE ID_REGISTRO = @Id";

                connection.Execute(query, new { Id = id });
            }
        }
    }
}
