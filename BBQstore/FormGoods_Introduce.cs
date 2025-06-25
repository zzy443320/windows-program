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
    public partial class FormGoods_Introduce : Form
    {
        public FormGoods_Introduce()
        {
            InitializeComponent();
        }

        public string Introduce; //商品介绍

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormGoods_Introduce_Load(object sender, EventArgs e)
        {
            if(FormGoods_Manage.Gname != null)
            {
                label1.Text = FormGoods_Manage.Introduce; //商品介绍
                pictureBox1.Image = Image.FromStream(new System.IO.MemoryStream(FormGoods_Manage.img)); //商品图片
            }
            
            if(FormGoods_Select.Gname != null)
            {
                label1.Text = FormGoods_Select.Introduce;
                pictureBox1.Image = Image.FromStream(new System.IO.MemoryStream(FormGoods_Select.img)); //商品图片
            }
        }
    }
}
