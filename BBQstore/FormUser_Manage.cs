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
    public partial class FormUser_Manage : Form
    {
        public FormUser_Manage()
        {
            InitializeComponent();
        }


        private void LoadUser()
        {
            DataBase db = new DataBase();
            db.connect(); //连接数据库
            string sql = "select * from T_User"; //查询所有商品信息
            SqlDataReader reader = db.reader(sql);
            string flag = "0";

            while (reader.Read())
            {
                if (reader[5].ToString() == flag)
                {
                    dgv.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(),
                    reader[3].ToString(), reader[4].ToString(), "NO"); //添加一行
                }
                else
                {
                    dgv.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(),
                    reader[3].ToString(), reader[4].ToString(), "YES"); //添加一行
                }
            }
            reader.Close();
            db.DataBaseClose();
        }

        private void FormUser_Manage_Load(object sender, EventArgs e)
        {
            LoadUser();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.CurrentRow == null || dgv.CurrentRow.Cells[0].Value == null)
            {
                MessageBox.Show("选中无效数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = dgv.CurrentRow.Cells[0].Value.ToString(); //获取选中行的ID
            string name = dgv.CurrentRow.Cells[2].Value.ToString(); //获取选中行的名称

            lblID.Text = id;
            lblName.Text = name; //显示在标签上
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //拿到关键字
            string key = txtKey.Text.Trim(); //去掉空格

            //进行查询
            DataBase db = new DataBase();
            db.connect();
            string sql = $"select * from T_User where Name like '%{key}%'";
            SqlDataReader reader = db.reader(sql);

            //清空表格
            dgv.Rows.Clear(); //清空表格控件中的数据

            //将查询到的数据添加到表格控件中
            string flag = "0";
            while (reader.Read())
            {
                if (reader[5].ToString() == flag)
                {
                    dgv.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(),
                    reader[3].ToString(), reader[4].ToString(), "NO"); //添加一行
                }
                else
                {
                    dgv.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(),
                    reader[3].ToString(), reader[4].ToString(), "YES"); //添加一行
                }
            }
            reader.Close();
            db.DataBaseClose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lblID.Text == "NULL")
            {
                MessageBox.Show("未选中用户！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("确定要删除该用户吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataBase db = new DataBase();
                db.connect();
                string sql = $"delete from T_User where Uid = {lblID.Text}"; 
                if (db.Execute(sql) > 0)
                {
                    //删除成功
                    MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    db.DataBaseClose(); //关闭数据库连接
                    dgv.Rows.Clear(); //清空表格控件中的数据

                    //修改对应的label的数据
                    lblID.Text = "NULL";
                    lblName.Text = "NULL";

                    //更新表格
                    dgv.Rows.Clear();
                    LoadUser(); //重新加载数据

                }
                else
                {
                    //删除失败
                    MessageBox.Show("删除失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    db.DataBaseClose(); //关闭数据库连接
                }
            }
            else
            {
                return;
            }
        }
    }
}
