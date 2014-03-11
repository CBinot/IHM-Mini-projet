using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Mini_projet.DAO
{
    class DAOParam
    {
        public string parameterName;
        public SqlDbType sqlDbType;
        public int size;
        public string sourceColumn;

        public DAOParam(string parameterName, SqlDbType sqlDbType,
            int size, string sourceColumn)
        {
            this.parameterName = parameterName;
            this.sqlDbType = sqlDbType;
            this.size = size;
            this.sourceColumn = sourceColumn;
        }
    }

    abstract class DAO
    {
        private const string CONNEC_STRING =
            "Data Source=sqlserver;" +
            "Database=*************;" +
            "User ID=invite11;" +
            "Password=l3si";

        private DataSet dataset;
        private SqlDataAdapter adapter;

        protected SqlConnection connection;
        protected string sqlSelect;
        protected string sqlInsert;
        protected string sqlUpdate;
        protected string sqlDelete;
        protected List<DAOParam> sqlParams;

        public void Initialiser()
        {
            // Vérifie que les requêtes existent
            if (sqlSelect == null || sqlSelect == "")
                throw new Exception(""); // TODO
            if (sqlInsert == null || sqlInsert == "")
                throw new Exception(""); // TODO
            if (sqlUpdate == null || sqlUpdate == "")
                throw new Exception(""); // TODO
            if (sqlDelete == null || sqlDelete == "")
                throw new Exception(""); // TODO

            // Instancie la connection
            connection = new SqlConnection(CONNEC_STRING);
            connection.Open();

            // Crée une instance d’objet DataSet
            dataset = new DataSet();

            // Crée une instance d’objet DataAdapter et renseigne ses requêtes
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(sqlSelect, connection);
            adapter.InsertCommand = new SqlCommand(sqlInsert, connection);
            adapter.UpdateCommand = new SqlCommand(sqlUpdate, connection);
            adapter.DeleteCommand = new SqlCommand(sqlDelete, connection);

            // Ajoute les paramètres nécessaires aux requêtes
            foreach (DAOParam param in sqlParams)
            {
                if (adapter.SelectCommand.CommandText.Contains(param.parameterName))
                    adapter.SelectCommand.Parameters.Add(param.parameterName, param.sqlDbType, param.size, param.sourceColumn);
                if (adapter.InsertCommand.CommandText.Contains(param.parameterName))
                    adapter.InsertCommand.Parameters.Add(param.parameterName, param.sqlDbType, param.size, param.sourceColumn);
                if (adapter.UpdateCommand.CommandText.Contains(param.parameterName))
                    adapter.UpdateCommand.Parameters.Add(param.parameterName, param.sqlDbType, param.size, param.sourceColumn);
                if (adapter.DeleteCommand.CommandText.Contains(param.parameterName))
                    adapter.DeleteCommand.Parameters.Add(param.parameterName, param.sqlDbType, param.size, param.sourceColumn);
            }

            // Remplis le dataset
            adapter.Fill(dataset);
            connection.Close();
        }
    }
}
