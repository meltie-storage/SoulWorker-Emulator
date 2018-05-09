// Licensed under the MIT license. See LICENSE file in the project root folder for full license information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Threading;

using MySql.Data.MySqlClient;
using SoulWorker.Framework.Logging;

namespace SoulWorker.Framework.Database
{
    public class MySqlBase : IDisposable
    {
        public int RowCount { get; set; }

        MySqlConnection Connection;
        string ConnectionString;

        public void Init(string host, string username, string password, string database, int port, bool pooling, int minPoolSize, int maxPoolSize)
        {
            if (pooling)
            {
                var pools = string.Format("Min Pool Size = {0}; Max Pool Size = {1};", minPoolSize, maxPoolSize);

                ConnectionString = "Server=" + host + ";User Id=" + username + "; Port=" + port + ";" +
                                   "Password=" + password + "; Database=" + database + "; Allow Zero Datetime = True;" +
                                   pools + "CharSet=utf8";
            }
            else
            {
                ConnectionString = "Server=" + host + "; User Id=" + username + "; Port=" + port + ";" +
                                   "Password=" + password + "; Database=" + database + "; Allow Zero Datetime = True;" +
                                   "Pooling=False; CharSet=utf8";
            }

            try
            {
                Connection = new MySqlConnection(ConnectionString);

                Connection.Open();
                Log.Message(LogType.Normal, "Successfully tested connection to {0}:{1}:{2}", host, port, database);
            }
            catch (MySqlException ex)
            {
                Log.Message(LogType.Error, "{0}", ex.Message);

                // Try auto reconnect on error (every 15 seconds)
                Log.Message(LogType.DB, "Try reconnect in 15 seconds...");
                Thread.Sleep(15000);

                Init(host, username, password, database, port, pooling, minPoolSize, maxPoolSize);
            }
        }

        public bool Execute(string sql, params object[] args)
        {
            StringBuilder sqlString = new StringBuilder();
            sqlString.AppendFormat(CultureInfo.GetCultureInfo("en-US").NumberFormat, sql);

            try
            {
                using (MySqlCommand sqlCommand = new MySqlCommand(sqlString.ToString(), Connection))
                {
                    var mParams = new List<MySqlParameter>(args.Length);

                    foreach (var a in args)
                        mParams.Add(new MySqlParameter("", a));

                    sqlCommand.Parameters.AddRange(mParams.ToArray());
                    sqlCommand.ExecuteNonQuery();
                }

                return true;
            }
            catch (MySqlException ex)
            {
                Log.Message(LogType.Error, "{0}", ex.Message);
                return false;
            }
        }

        public SQLResult Select(string sql, params object[] args)
        {
            StringBuilder sqlString = new StringBuilder();
            sqlString.AppendFormat(CultureInfo.GetCultureInfo("en-US").NumberFormat, sql);

            try
            {
                using (var sqlCommand = new MySqlCommand(sqlString.ToString(), Connection))
                {
                    var mParams = new List<MySqlParameter>(args.Length);

                    foreach (var a in args)
                        mParams.Add(new MySqlParameter("", a));

                    sqlCommand.Parameters.AddRange(mParams.ToArray());

                    using (var SqlData = sqlCommand.ExecuteReader(CommandBehavior.Default))
                    {
                        using (var retData = new SQLResult())
                        {
                            retData.Load(SqlData);
                            retData.Count = retData.Rows.Count;

                            return retData;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Log.Message(LogType.Error, "{0}", ex.Message);
            }

            return null;
        }

        public void ExecuteBigQuery(string table, string fields, int fieldCount, int resultCount, object[] values, bool resultAsIndex = true)
        {
            if (values.Length > 0)
            {
                StringBuilder sqlString = new StringBuilder();

                sqlString.AppendFormat("INSERT INTO {0} ({1}) VALUES ", table, fields);

                for (int i = 0; i < resultCount; i++)
                {
                    sqlString.AppendFormat("(", CultureInfo.InvariantCulture);

                    for (int j = 0; j < fieldCount; j++)
                    {
                        int index = resultAsIndex ? i : j;

                        if (j == fieldCount - 1)
                            sqlString.Append(string.Format(CultureInfo.GetCultureInfo("en-US").NumberFormat, "'{0}'", values[index]));
                        else
                            sqlString.Append(string.Format(CultureInfo.GetCultureInfo("en-US").NumberFormat, "'{0}', ", values[index]));
                    }

                    if (i == resultCount - 1)
                        sqlString.AppendFormat(");", CultureInfo.InvariantCulture);
                    else
                        sqlString.AppendFormat("),", CultureInfo.InvariantCulture);
                }

                MySqlCommand sqlCommand = new MySqlCommand(sqlString.ToString(), Connection);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            Connection.Close();
            ConnectionString = null;
        }
    }
}
