using Dapper;
using ProjetoDOS03.Entities;
using ProjetoDOS03.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDOS03.Repository
{
    /// <summary>
    /// Classe de repositorio de dados para a entidade Produto
    /// </summary>
    public class ProdutoRepository : IBaseRepository<Produto>
    {
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = BDEXProdutos; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Create(Produto obj)
        {
            var sql = @"
                    INSERT INTO PRODUTO(IDPRODUTO, NOME, PRECO, QUANTIDADE, DATACOMPRA)
                    VALUES(@IdProduto, @Nome, @Preco, @Quantidade, @DataCompra)
                    ";

            //abrindo a conexão com o sqlserver
            using (var connection = new SqlConnection(_connectionString))
            {
                //executando o comando com Dapper
                connection.Execute(sql, obj);
            }
        }

        public void Update(Produto obj)
        {
            var sql = @"
                    UPDATE PRODUTO SET
                    NOME = @Nome,
                    PRECO = @Preco,
                    QUANTIDADE = Quantidade,
                    DATACOMPRA = DataCompra
                WHERE
                    IDPRODUTO = @IdProduto
                    ";
            
            //abrindo a conexão com o sqlserver
            using (var connection = new SqlConnection(_connectionString))
            {
                //executando o comando com Dapper
                connection.Execute(sql, obj);
            }
        }

        public void Delete(Produto obj)
        {
            var sql = @"
                    DELETE FROM PRODUTO
                    WHERE IDPRODUTO = @IdProduto
                ";

            //abrindo a conexão com o sqlserver
            using (var connection = new SqlConnection(_connectionString))
            {
                //executando o comando com Dapper
                connection.Execute(sql, obj);
            }
        }

        public List<Produto> GetAll()
        {
            var sql = @"
                    SELECT * FROM PRODUTO
                    ORDER BY NOME ASC
                ";

            //abrindo a conexão com o sqlserver
            using (var connection = new SqlConnection(_connectionString))
            {
                //executando o comando com Dapper e retornar o resultado
                return connection.Query<Produto>(sql).ToList();
            }
        }
    }
}
