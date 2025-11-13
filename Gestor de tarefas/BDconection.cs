using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Gestor_de_tarefas
{
    internal class BDconection
    {
        private string strConexao = "server=localhost;port=3306;database=tarefas;user=root;password=Erlander;";
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(strConexao);
        }

        
    }
}
