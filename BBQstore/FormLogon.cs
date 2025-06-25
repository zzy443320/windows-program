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
    public partial class FormLogon : Form
    {
        public FormLogon()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            //先判断文本框是否为空
            if (txtName.Text == "" || txtTel.Text == "" || txtPwd.Text == "" || txtID.Text == "" || cobSex.Text == "")
            {
                //提示有空项
                MessageBox.Show("还有内容未填写，请填写完整", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //注册
            DataBase db = new DataBase();
            db.connect();   //连接并打开数据库
            string id = txtID.Text;
            string sql = $"select * from T_User where Uid = {id}";
            SqlDataReader reader = db.reader(sql); //执行sql语句，返回SqlDataReader对象

            if (reader.Read())    //reader.Read(); 读取数据
            {
                //提示账号已存在
                MessageBox.Show("账号已存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string name = txtName.Text;
            string pwd = txtPwd.Text;
            string tel = txtTel.Text;
            string sex = cobSex.Text;

            //进行添加
            sql = $"insert into T_User values('{id}', '{pwd}', '{name}', '{sex}', '{tel}', '1')";
            if (db.Execute(sql) > 0)
            {
                //注册成功
                MessageBox.Show("注册成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); //关闭当前窗口
            }
            else
            {
                //注册失败
                MessageBox.Show("注册失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //关闭数据库连接
            reader.Close(); //关闭SqlDataReader对象
            db.DataBaseClose(); //关闭数据库连接
        }
    }
}
