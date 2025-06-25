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
    public partial class FormGoods_Manage : Form
    {
        public FormGoods_Manage()
        {
            InitializeComponent();
        }

        //商品信息
        public static int Gid;
        public static string Gname;
        public static string Introduce;
        public static float Price;
        public static string Type;
        public static int Num;
        public static string Discount;
        public static byte[] img;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadGoods()
        {
            DataBase db = new DataBase();
            db.connect(); //连接数据库
            string sql = "select * from T_Goods"; //查询所有商品信息
            SqlDataReader reader = db.reader(sql);

            while (reader.Read())
            {
                dgv.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(),
                    reader[3].ToString(), reader[4].ToString(), reader[5].ToString(),
                    reader[6].ToString(), reader[7].ToString()); //添加一行
            }
            reader.Close();
            db.DataBaseClose();
        }

        private void FormGoods_Manage_Load(object sender, EventArgs e)
        {
            //在窗体加载的同时将数据库中的商品信息显示到表格控件当中
            LoadGoods();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //拿到关键字
            string key = txtKey.Text.Trim(); //去掉空格

            //进行查询
            DataBase db = new DataBase();
            db.connect();
            string sql = $"select * from T_Goods where Gname like '%{key}%' or Type like '%{key}%'";
            SqlDataReader reader = db.reader(sql);

            //清空表格
            dgv.Rows.Clear(); //清空表格控件中的数据

            //将查询到的数据添加到表格控件中
            while (reader.Read())
            {
                dgv.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(),
                    reader[3].ToString(), reader[4].ToString(), reader[5].ToString(),
                    reader[6].ToString(), reader[7].ToString()); //添加一行
            }
            reader.Close();
            db.DataBaseClose();

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.CurrentRow == null || dgv.CurrentRow.Cells[0].Value == null)
            {
                MessageBox.Show("选中无效数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = dgv.CurrentRow.Cells[0].Value.ToString(); //获取选中行的ID
            string name = dgv.CurrentRow.Cells[1].Value.ToString(); //获取选中行的名称

            lblID.Text = id;
            lblName.Text = name; //显示在标签上

            Gid = int.Parse(dgv.CurrentRow.Cells[0].Value.ToString());
            Gname = dgv.CurrentRow.Cells[1].Value.ToString();
            Introduce = dgv.CurrentRow.Cells[2].Value.ToString();
            Price = float.Parse(dgv.CurrentRow.Cells[3].Value.ToString());
            Type = dgv.CurrentRow.Cells[4].Value.ToString();
            Num = int.Parse(dgv.CurrentRow.Cells[5].Value.ToString());
            Discount = dgv.CurrentRow.Cells[6].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //刷新数据
            dgv.Rows.Clear(); //清空表格控件中的数据
            LoadGoods();
        }

        private void btnIntroduce_Click(object sender, EventArgs e)
        {
            if(lblName.Text == "NULL")
            {
                MessageBox.Show("未选中商品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataBase db = new DataBase();
            db.connect(); //连接数据库
            string sql = $"select Introduce, Picture from T_Goods where Gid = {lblID.Text}"; //查询商品介绍
            SqlDataReader reader = db.reader(sql); //执行sql语句，返回SqlDataReader对象
            reader.Read();
            string introduce = reader[0].ToString(); //获取商品介绍
            byte[] imageData = (byte[])reader[1]; // 直接获取二进制数据
            img = imageData;

            //通过对话框显示商品介绍
            FormGoods_Introduce form = new FormGoods_Introduce();
            form.ShowDialog();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            FormGoods_Update form = new FormGoods_Update();
            form.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //获取到选中商品的编号
            if (lblID.Text == "NULL")
            {
                MessageBox.Show("未选中商品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //删除数据库中的数据
            DataBase db = new DataBase();
            db.connect(); //连接数据库
            string sql = $"delete from T_Goods where Gid = {int.Parse(lblID.Text)}"; //删除商品
            if (db.Execute(sql) > 0)
            {
                //删除成功
                MessageBox.Show("下架成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.DataBaseClose(); //关闭数据库连接
                dgv.Rows.Clear(); //清空表格控件中的数据

                //修改对应的label的数据
                lblID.Text = "NULL";
                lblName.Text = "NULL";

                //更新表格
                dgv.Rows.Clear();
                LoadGoods(); //重新加载数据

            }
            else
            {
                //删除失败
                MessageBox.Show("删除失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                db.DataBaseClose(); //关闭数据库连接
            }
        }
    }
}
