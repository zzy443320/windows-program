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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //用户/管理员的账号和姓名
        public static string id;
        public static string name;

        //管理员登录的函数
        private void AdminLogin()
        {
            //获取账号和密码
            string id = txtId.Text;
            string pwd = txtPassword.Text;

            //连接数据库
            DataBase db = new DataBase();
            db.connect();   //连接并打开数据库
            string sql = $"select * from T_Admin where AdminID = '{id}' and Pwd = '{pwd}'";
            SqlDataReader reader = db.reader(sql); //执行sql语句，返回SqlDataReader对象
            if (reader.Read() == true)    //reader.Read(); 读取数据
            {
                //说明数据库中有该管理员信息
                Form1.id = id;   //将账号存入静态变量中 
                sql = $"select [Name] from T_Admin where AdminID = {id}";
                reader = db.reader(sql);
                reader.Read();
                Form1.name = reader[0].ToString();

                //清空管理员所输入的信息
                txtId.Text = "";
                txtPassword.Text = "";

                //关闭数据库
                reader.Close();
                db.DataBaseClose();

                //登录成功
                FormAdmin form = new FormAdmin();
                form.ShowDialog();
            }
            else 
            {
                MessageBox.Show("账号或密码错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //用户登录的函数
        private void UserLogin()
        {
            //获取账号和密码
            string id = txtId.Text;
            string pwd = txtPassword.Text;

            //连接数据库
            DataBase db = new DataBase();
            db.connect();   //连接并打开数据库
            string sql = $"select * from T_User where Uid = '{id}' and Pwd = '{pwd}'";
            SqlDataReader reader = db.reader(sql); //执行sql语句，返回SqlDataReader对象
            if (reader.Read() == true)    //reader.Read(); 读取数据
            {
                //说明数据库中有该用户信息
                Form1.id = id;   //将账号存入静态变量中 
                sql = $"select [Name] from T_User where Uid = {id}";
                reader = db.reader(sql);
                reader.Read();
                Form1.name = reader[0].ToString();

                //清空用户所输入的信息
                txtId.Text = "";
                txtPassword.Text = "";

                //关闭数据库
                reader.Close();
                db.DataBaseClose();

                //登录成功
                FormUser form = new FormUser();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("账号或密码错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        //点击注册触发的函数
        private void btnLogon_Click(object sender, EventArgs e)
        {
            FormLogon form = new FormLogon();
            form.ShowDialog(); // ShowDialog()方法会阻塞当前线程，直到对话框关闭
        }

        //点击退出触发的函数
        private void btnExit_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("确定要退出吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Application.Exit(); // 退出应用程序
            }
        }

        //点击登录触发的函数
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //判断文本框是否有内容
            if (txtId.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("请填写账号或密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //判断登录的是用户还是管理员
            if (rbtnAdmin.Checked == true)   //登录的是管理员
            {
                AdminLogin();
            }

            if (rbtnUser.Checked == true)    //登录的是用户
            {
                UserLogin();
            }
        }
    }
}
