using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BBQstore
{
    public partial class FormGoods_Select : Form
    {
        public FormGoods_Select()
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

        public static int Quantity; 

        public static int cid;

        public static float Pay;
        public static float sum = 0;


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

        private void button4_Click(object sender, EventArgs e)
        {
            //刷新数据
            dgv.Rows.Clear(); //清空表格控件中的数据
            LoadGoods();
        }

        private void btnIntroduce_Click(object sender, EventArgs e)
        {
            if (lblName.Text == "NULL")
            {
                MessageBox.Show("未选中商品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataBase db = new DataBase();
            db.connect(); //连接数据库
            string sql = $"select Introduce, Picture from T_Goods where Gid = {Gid}"; //查询商品介绍
            SqlDataReader reader = db.reader(sql); //执行sql语句，返回SqlDataReader对象
            reader.Read();
            string introduce = reader[0].ToString(); //获取商品介绍
            byte[] imageData = (byte[])reader[1]; // 直接获取二进制数据
            img = imageData;

            //通过对话框显示商品介绍
            FormGoods_Introduce form = new FormGoods_Introduce();
            form.ShowDialog();
        }

        private void FormGoods_Select_Load(object sender, EventArgs e)
        {
            LoadGoods();

            string uid = Form1.id;
            string name = Form1.name;

            DataBase db = new DataBase();
            db.connect();

            // 合并插入和查询语句
            string sql = $@"
    INSERT INTO T_Car (Uid, Uname) VALUES ('{uid}', '{name}');
    SELECT SCOPE_IDENTITY();";

            SqlDataReader reader = db.reader(sql);
            reader.Read();  // 移动到第一条记录
            cid = int.Parse(reader[0].ToString());  // 获取CID值

            reader.Close();
            db.DataBaseClose();

        }


        private void dgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.CurrentRow == null || dgv.CurrentRow.Cells[0].Value == null)
            {
                MessageBox.Show("选中无效数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string name = dgv.CurrentRow.Cells[1].Value.ToString(); //获取选中行的名称
            lblName.Text = name; //显示在标签上

            Gid = int.Parse(dgv.CurrentRow.Cells[0].Value.ToString());
            Gname = dgv.CurrentRow.Cells[1].Value.ToString();
            Introduce = dgv.CurrentRow.Cells[2].Value.ToString();
            Price = float.Parse(dgv.CurrentRow.Cells[3].Value.ToString());
            Type = dgv.CurrentRow.Cells[4].Value.ToString();
            Num = int.Parse(dgv.CurrentRow.Cells[5].Value.ToString());
            Discount = dgv.CurrentRow.Cells[6].Value.ToString();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int count = int.Parse(comboBox1.Text);

            if(lblName.Text == null)
            {
                MessageBox.Show("未选中商品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (count == 0)
            {
                MessageBox.Show("未选择购买数量！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //判断库存是否充足
            if(int.Parse(comboBox1.Text) > Num)
            {
                MessageBox.Show("库存不足！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            Quantity = int.Parse(comboBox1.Text); //获取购买数量
            Pay = Quantity * Price;
            sum = sum + Pay; 

            DataBase db = new DataBase();
            db.connect();

            // 不需要指定ItemID，数据库会自动生成
            string sql = $"insert into T_CarItem (Cid, Gid, Gname, Discount, Price, Quantity, Pay) values ('{cid}', '{Gid}', '{Gname}', '{Discount}', '{Price}', '{Quantity}', '{Pay}')";
   
            if (db.Execute(sql) != 0)
            {
                MessageBox.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.DataBaseClose(); //关闭数据库连接
            }
            else
            {
                MessageBox.Show("添加失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                db.DataBaseClose(); //关闭数据库连接
            }

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            FormGoods_Car form = new FormGoods_Car();
            form.ShowDialog(); //打开购物车窗口
        }
    }
}
