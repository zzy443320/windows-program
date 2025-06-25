using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBQstore
{
    public partial class FormGoods_Update : Form
    {
        public FormGoods_Update()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //先判断文本框是否为空
            if (txtName.Text.Trim() == "" || txtID.Text.Trim() == "" || txtPrice.Text.Trim() == "" || txtDiscount.Text.Trim() == "" || txtType.Text.Trim() == "" || txtIntroduce.Text.Trim() == "" || txtNum.Text.Trim() == "")
            {
                MessageBox.Show("还有内容未填写，请填写完整", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //修改商品信息
            DataBase db = new DataBase();
            db.connect();   //连接并打开数据库
            string sql = $"update T_Goods set Gid = '{int.Parse(txtID.Text)}', Gname = '{txtName.Text}', Introduce = '{txtIntroduce.Text}', Price = '{float.Parse(txtPrice.Text)}', Type = '{txtType.Text}', Num = '{int.Parse(txtNum.Text)}', Discount = '{txtDiscount.Text}' where Gid = '{FormGoods_Manage.Gid}'";
            if(db.Execute(sql) > 0)
            {
                //修改成功
                MessageBox.Show("修改成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.DataBaseClose(); //关闭数据库连接
                this.Close();
            }
            else
            {
                MessageBox.Show("修改失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                db.DataBaseClose(); //关闭数据库连接
            }
        }

        private void FormGoods_Update_Load(object sender, EventArgs e)
        {
            txtID.Text = FormGoods_Manage.Gid.ToString();
            txtName.Text = FormGoods_Manage.Gname;
            txtIntroduce.Text = FormGoods_Manage.Introduce;
            txtPrice.Text = FormGoods_Manage.Price.ToString();
            txtType.Text = FormGoods_Manage.Type;
            txtNum.Text = FormGoods_Manage.Num.ToString();  
            txtDiscount.Text = FormGoods_Manage.Discount;
        }
    }
}
