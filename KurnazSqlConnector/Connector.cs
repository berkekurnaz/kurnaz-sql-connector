using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace KurnazSqlConnector
{
    public class Connector<T> where T : class, new()
    {

        private string _connectionString;

        private SqlConnection _connection;

        public Connector(string connectionString)
        {
            this._connectionString = connectionString;
            _connection = new SqlConnection(_connectionString);
        }

        /// <summary>
        /// This method list all record from tables
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<T> List(string tableName)
        {
            List<T> mylist = new List<T>();

            try
            {
                _connection.Open();
                SqlCommand _command = new SqlCommand();
                _command.CommandText = "Select * From " + tableName;
                _command.Connection = _connection;

                SqlDataReader dr;
                dr = _command.ExecuteReader();
                while (dr.Read())
                {
                    T item = new T();
                    for (int i = 0; i < item.GetType().GetProperties().Count(); i++)
                    {
                        item.GetType().GetProperties()[i].SetValue(item, ConvertValueType.ConvertObject(dr[item.GetType().GetProperties()[i].Name].ToString(), item.GetType().GetProperties()[i].PropertyType.ToString()));
                    }
                    mylist.Add(item);
                }
                _connection.Close();
            }
            catch
            {

            }

            return mylist;
        }

        /// <summary>
        /// This method add new record to your table.
        /// </summary>
        /// <param name="tableName">Your table name</param>
        /// <param name="areas">Your field</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public bool AddWithSqlQuery(string tableName, string[] areas, string[] parameters)
        {
            try
            {
                _connection.Open();

                string areasFull = "(";
                foreach (var item in areas)
                {
                    if (!item.Contains(","))
                    {
                        areasFull += item + ",";
                    }
                    else
                    {
                        return false;
                    }
                }
                areasFull = areasFull.Remove(areasFull.Length - 1);
                areasFull = areasFull + ")";

                string parametersFull = "(";
                for (int i = 1; i <= parameters.Length; i++)
                {
                    parametersFull += "@p" + i.ToString() + ",";
                }
                parametersFull = parametersFull.Remove(parametersFull.Length - 1);
                parametersFull = parametersFull + ")";

                SqlCommand _command = new SqlCommand("Insert Into " + tableName + areasFull + " values " + parametersFull, _connection);
                for (int i = 1; i <= parameters.Length; i++)
                {
                    string parameter = "@p" + i.ToString();
                    _command.Parameters.AddWithValue(parameter, parameters[i - 1]);
                }
                _command.ExecuteNonQuery();
                _connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// This method delete a record by condition
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <returns></returns>
        public bool DeleteWithSqlQuery(string tableName, string area, string parameter)
        {
            try
            {
                _connection.Open();
                SqlCommand _command = new SqlCommand("Delete From " + tableName + " where " + area + "=@p1", _connection);
                _command.Parameters.AddWithValue("@p1", parameter);
                _command.ExecuteNonQuery();
                _connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="areas"></param>
        /// <param name="parameters"></param>
        /// <param name="deleteArea"></param>
        /// <param name="deleteParameter"></param>
        /// <returns></returns>
        public bool UpdateWithSqlQuery(string tableName, string[] areas, string[] parameters, string deleteArea, string deleteParameter)
        {
            try
            {
                _connection.Open();

                string updateQuery = "";
                if (areas.Length == parameters.Length)
                {
                    for (int i = 0; i < areas.Length; i++)
                    {
                        if (i == areas.Length - 1)
                        {
                            updateQuery += areas[i] + "=@P" + (i + 1).ToString();
                        }
                        else
                        {
                            updateQuery += areas[i] + "=@P" + (i + 1).ToString() + ",";
                        }
                    }
                }

                SqlCommand _command = new SqlCommand("Update " + tableName + " set " + updateQuery + " where " + deleteArea + "=@pdelete", _connection);
                for (int i = 1; i <= parameters.Length; i++)
                {
                    string parameter = "@p" + i.ToString();
                    _command.Parameters.AddWithValue(parameter, parameters[i - 1]);
                }
                _command.Parameters.AddWithValue("@pdelete", deleteParameter);
                _command.ExecuteNonQuery();
                _connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
