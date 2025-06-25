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
using System.Xml.Linq;

namespace BBQstore
{
    public partial class FormUser_comment : Form
    {
        public FormUser_comment()
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

        private void rbtn2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FormUser_comment_Load(object sender, EventArgs e)
        {
            LoadComment();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtComment.Text.Trim() == "")
            {
                MessageBox.Show("请填写评价！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(rbtn1.Checked == false && rbtn2.Checked == false && rbtn3.Checked == false && rbtn4.Checked == false && rbtn5.Checked == false) 
            {
                MessageBox.Show("请给出推荐指数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = Form1.id;
            string str = "";
            if (rbtn1.Checked) str = "1颗星";
            else if (rbtn2.Checked) str = "2颗星";
            else if (rbtn3.Checked) str = "3颗星";
            else if (rbtn4.Checked) str = "4颗星";
            else if (rbtn5.Checked) str = "5颗星";

            DataBase db = new DataBase();
            db.connect();

            string sql = $"insert into T_Reviews (uid, comment, star) values('{id}', '{txtComment.Text.Trim()}', '{str}')";
            if (db.Execute(sql) > 0)
            {
                db.DataBaseClose();
                MessageBox.Show("发表成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtComment.Text = "";
                rbtn1.Checked = false;
                rbtn2.Checked = false;
                rbtn3.Checked = false;
                rbtn4.Checked = false;
                rbtn5.Checked = false;

                dgv.Rows.Clear();
                LoadComment();
            }
            else
            {
                MessageBox.Show("发表失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
