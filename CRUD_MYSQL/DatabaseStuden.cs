using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_MYSQL
{
    internal class DatabaseStuden
    {
        public static MySqlConnection GetConnectio()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=example;database=student";
            MySqlConnection conn = new MySqlConnection(sql);
            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Mysql Connection Error", ex.Message);
            }
        return conn;
        }
        public static void AddStudent(student std)
        {
            string sql = "INSERT INTO `student_tabe` (`name`, `reg`, `class`, `section`, `createAt`) VALUES (@StdName,@StdReg, @StdClass, @StdSection, now());";
            MySqlConnection conn = GetConnectio();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@StdName", MySqlDbType.VarChar).Value = std.Name;
            cmd.Parameters.Add("@StdReg", MySqlDbType.VarChar).Value = std.Reg;
            cmd.Parameters.Add("@StdClass", MySqlDbType.VarChar).Value = std.Class;
            cmd.Parameters.Add("@StdSection", MySqlDbType.VarChar).Value = std.Section;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("New Student successfully","Information",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            catch (MySqlException ex) {
                MessageBox.Show("Mysql Connection Error", ex.Message);
            }
            finally { conn.Close(); }
        }
        public static void UpdateStudent(student std,string id)
        {
            string sql = "UPDATE `student_tabe` SET name =  @StdName, reg = @StdReg, class = @StdClass, section = @StdSection WHERE id = @StdId";
            MySqlConnection conn = GetConnectio();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@StdName", MySqlDbType.VarChar).Value = std.Name;
            cmd.Parameters.Add("@StdReg", MySqlDbType.VarChar).Value = std.Reg;
            cmd.Parameters.Add("@StdClass", MySqlDbType.VarChar).Value = std.Class;
            cmd.Parameters.Add("@StdSection", MySqlDbType.VarChar).Value = std.Section;
            cmd.Parameters.Add("@StdId", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Student successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Mysql Connection Error", ex.Message);
            }
            finally { conn.Close(); }
        }
        public static void DeleteStuden(string id)
        {
            string sql = "DELETE FROM student_tabe WHERE id = @StdId";
            MySqlConnection conn = GetConnectio();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@StdId", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("delete Student successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Mysql Connection Error", ex.Message);
            }
            finally { conn.Close(); }
        }
        public static void DisplayAndSearch(string query,DataGridView dgv)
        {
            string sql = query;
            MySqlConnection conn = GetConnectio();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl  = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            conn.Close();

        }
    }
}
