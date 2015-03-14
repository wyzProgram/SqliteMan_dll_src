/**
 *wyz 2015.3.14 shanghai 858272689@qq.com  x86 SqliteMan
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using System.Data;

namespace SqliteMan
{
    public class Run
    {
        /// <summary>
        /// 创建sqlitefile文件
        /// </summary>
        /// <param name="filepath">sqlite完整文件路径</param>
        public static void createSqlite(string filepath)
        {
            SQLiteConnection.CreateFile(filepath);
        }

        /// <summary>
        /// 执行sql
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="connectString">连接字符串</param>
        /// <returns></returns>
        public static int Query(string sql,string connectString)
        {
            SQLiteConnection conn = new SQLiteConnection(connectString);
            conn.Open();
            SQLiteCommand com = new SQLiteCommand(sql, conn);
            int ret = com.ExecuteNonQuery();
            conn.Close();
            return ret;
        }

        /// <summary>
        /// 查询sql，返回datatable
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="connectString">连接字符串</param>
        /// <returns></returns>
        public static DataTable selectsql(string sql,string connectString)
        {
            try 
            {
                SQLiteConnection conn = new SQLiteConnection(connectString);
                conn.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                return ds.Tables[0];
            }
            catch(Exception ex)
            {
                string err = ex.Message;
                return null;
            }
        }
    }
}