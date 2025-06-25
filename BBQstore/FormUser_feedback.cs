using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BBQstore
{
    public partial class FormUser_feedback : Form
    {
        public FormUser_feedback()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("你没有输入任何内容！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string feedback = textBox1.Text.ToString();
            DataBase db = new DataBase();
            db.connect();

            string sql = $"insert into T_FeedBack (uid, name, feedback) values('{Form1.id}', '{Form1.name}', '{feedback}')";

            if (db.Execute(sql) > 0)
            {
                db.DataBaseClose();
                MessageBox.Show("提交成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
        
               
            }
            else
            {
                MessageBox.Show("发表失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.DataBaseClose();
            }
        }
    }
}
