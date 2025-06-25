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
    public partial class FormUpdatePwd_Admin : Form
    {
        public FormUpdatePwd_Admin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //先判断文本框是否为空
            if (txtOldPwd.Text == "" || txtNewPwd.Text == "" || txtOkPwd.Text == "")
            {
                MessageBox.Show("还有内容未填写，请填写完整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //新密码和确认密码不匹配
            if (txtNewPwd.Text != txtOkPwd.Text)
            {
                MessageBox.Show("新密码和确认密码不匹配！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //原密码是否与数据库中的匹配
            DataBase db = new DataBase();
            db.connect();   //连接并打开数据库
            string sql = $"select Pwd from T_Admin where AdminID = {Form1.id}";
            SqlDataReader reader = db.reader(sql); //执行sql语句，返回SqlDataReader对象
            reader.Read();
            if (reader[0].ToString() != txtOldPwd.Text)
            {
                //原密码错误
                MessageBox.Show("原密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                //修改密码
                sql = $"update T_Admin set Pwd = '{txtNewPwd.Text}' where AdminID = {Form1.id}";
                if (db.Execute(sql) > 0)
                {
                    //修改成功
                    MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reader.Close(); //关闭SqlDataReader对象
                    db.DataBaseClose();
                    this.Close(); //关闭当前窗口
                }
                else
                {
                    //修改失败
                    MessageBox.Show("修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    db.DataBaseClose();
                }
            }
            catch
            {
                MessageBox.Show("ERROR！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
