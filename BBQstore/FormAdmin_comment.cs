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
    public partial class FormAdmin_comment : Form
    {
        public FormAdmin_comment()
        {
            InitializeComponent();
        }

        private void LoadComment()
        {
            DataBase db = new DataBase();
            db.connect(); //连接数据库
            string sql = "select * from T_Reviews"; //查询评论
            SqlDataReader reader = db.reader(sql);


            while (reader.Read())
            {
                dgv.Rows.Add(reader[1].ToString(), reader[2].ToString(), reader[3].ToString()); //添加一行
            }
            reader.Close();
            db.DataBaseClose();
        }

        private void FormAdmin_comment_Load(object sender, EventArgs e)
        {
            LoadComment();
        }
    }
}
