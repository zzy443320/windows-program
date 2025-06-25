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
    public partial class FormAdmin_feedback : Form
    {
        public FormAdmin_feedback()
        {
            InitializeComponent();
        }

        private void LoadFeedback()
        {
            DataBase db = new DataBase();
            db.connect(); //连接数据库
            string sql = "select * from T_FeedBack"; 
            SqlDataReader reader = db.reader(sql);
            

            while (reader.Read())
            {
                dgv.Rows.Add(reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString()); //添加一行
            }
            reader.Close();
            db.DataBaseClose();
        }

        private void FormAdmin_feedback_Load(object sender, EventArgs e)
        {
            LoadFeedback();
        }
    }
}
