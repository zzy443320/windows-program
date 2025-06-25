using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBQstore
{
    public partial class FormAddGoods : Form
    {
        public FormAddGoods()
        {
            InitializeComponent();
        }

        //商品图片
        public byte[] img;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //先判断文本框是否为空
            if(txtName.Text.Trim() == "" || txtID.Text.Trim() == "" || txtPrice.Text.Trim() == "" || txtDiscount.Text.Trim() == "" || txtType.Text.Trim() == "" || txtIntroduce.Text.Trim() == "" || txtNum.Text.Trim() == "")
            {
                MessageBox.Show("还有内容未填写，请填写完整", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            

            //添加图书
            DataBase db = new DataBase();
            SqlConnection connection = null;
            connection = db.connect();

            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Gid", int.Parse(txtID.Text)));
            par.Add(new SqlParameter("@Gname", txtName.Text));
            par.Add(new SqlParameter("@Introduce", txtIntroduce.Text));
            par.Add(new SqlParameter("@Price", float.Parse(txtPrice.Text)));
            par.Add(new SqlParameter("@Type", txtType.Text));
            par.Add(new SqlParameter("@Num", int.Parse(txtNum.Text)));
            par.Add(new SqlParameter("@Discount", txtDiscount.Text));
            par.Add(new SqlParameter("@Sale", SqlDbType.Int) { Value = 0 });
            par.Add(new SqlParameter("@Picture", SqlDbType.Image) { Value = img});

            string sql = @"INSERT INTO T_Goods (Gid, Gname, Introduce, Price, Type, Num, Discount, Sale, Picture) 
               VALUES (@Gid, @Gname, @Introduce, @Price, @Type, @Num, @Discount, @Sale, @Picture)";
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddRange(par.ToArray());
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("添加成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    db.DataBaseClose(); //关闭数据库连接
                    this.Close();
                }
                else
                {
                    MessageBox.Show("添加失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    db.DataBaseClose();
                }
            }
        }

        private void btnImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "选择上传的商品图片";
            open.Filter = "图片文件|*.jpg;*.jpeg;*.png;*.bmp"; // 限制只能选择图片文件
            if (open.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            byte[] bytes = System.IO.File.ReadAllBytes(open.FileName);
            img = bytes; //将图片转换为字节数组
            if(img != null)
            {
                MessageBox.Show("上传成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                MessageBox.Show("上传失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void FormAddGoods_Load(object sender, EventArgs e)
        {

        }
    }
}
