using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBQstore
{
    public partial class FormOrder_User : Form
    {
        public FormOrder_User()
        {
            InitializeComponent();
        }

        private void LoadOrder()
        {
            string id = Form1.id;
            DataBase db = new DataBase();
            db.connect(); //连接数据库
            string sql = $"select * from T_Order where uid = '{id}'"; 
            SqlDataReader reader = db.reader(sql);


            while (reader.Read())
            {
                dgv.Rows.Add(reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString()); //添加一行
            }
            reader.Close();
            db.DataBaseClose();
        }
        private void FormOrder_User_Load(object sender, EventArgs e)
        {
            LoadOrder();
        }
    }
}
