using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuapiGraph.Utils
{
    /// <summary>
    /// 使用该库时，要确保已设置系统数据源，并且vs能连接上数据库
    /// 默认的数据源设置是  Dsn=csharp   uid=root
    /// </summary>
    class DBUtils
    {
        private string str_conn = "";

        /// <summary>
        /// 设置Dsn 和 uid。 默认 Dsn = csharp， uid = root
        /// </summary>
        public DBUtils() : this("csharp", "root")
        {

        }

        /// <summary>
        /// 设置Dsn 和 uid
        /// </summary>
        /// <param name="Dsn"></param>
        /// <param name="uid"></param>
        public DBUtils(string Dsn, string uid)
        {
            str_conn = @"Dsn=" + Dsn + ";uid=" + uid;
        }

        /// <summary>
        /// 执行一般sql语句
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public int ExecuteCmd(string cmd)
        {
            using (OdbcConnection conn = OpenConnection())
            {
                OdbcCommand odbc = new OdbcCommand(cmd, conn);

                Console.WriteLine("DBUtils.ExecuteCmd cmd : " + cmd);
                //Console.WriteLine("DBUtils.ExecuteCmd cmd ");

                return odbc.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 异步执行一般sql语句
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public Task<int> ExecuteCmdAsync(string cmd)
        {
            using (OdbcConnection conn = OpenConnection())
            {
                OdbcCommand odbc = new OdbcCommand(cmd, conn);

                Console.WriteLine("DBUtils.ExecuteCmdAsync cmd : " + cmd);
                //Console.WriteLine("DBUtils.ExecuteCmdAsync cmd");

                return odbc.ExecuteNonQueryAsync();
            }
        }

        /// <summary>
        /// sql查询语句
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public DataSet QueryCmd(string cmd)
        {
            using (OdbcConnection conn = OpenConnection())
            {
                DataSet set = new DataSet();
                OdbcDataAdapter adapter = new OdbcDataAdapter(cmd, conn);

                adapter.FillSchema(set, SchemaType.Mapped);
                adapter.Fill(set);

                Console.WriteLine("DBUtils.QueryCmd cmd : " + cmd);

                return set;
            }
        }

        /// <summary>
        /// 专门用于查询统计个数
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public int CountCmd(string cmd)
        {
            using (OdbcConnection conn = OpenConnection())
            {
                OdbcCommand command = new OdbcCommand(cmd, conn);

                int count = Convert.ToInt32(command.ExecuteScalar());

                Console.WriteLine("DBUtils.CountCmd cmd : " + cmd);

                return count;
            }
        }

        /// <summary>
        /// 打开数据库的连接
        /// </summary>
        private OdbcConnection OpenConnection()
        {
            OdbcConnection conn = new OdbcConnection(str_conn);

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            Console.WriteLine("open odbc db connection");
            return conn;
        }
    }
}
