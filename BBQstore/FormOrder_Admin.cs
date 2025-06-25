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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace BBQstore
{
    public partial class FormOrder_Admin : Form
    {
        public FormOrder_Admin()
        {
            InitializeComponent();
        }

        public static string Oid;
        private void LoadOrder()
        {
            DataBase db = new DataBase();
            db.connect(); //连接数据库
            string sql = $"select * from T_Order";
            SqlDataReader reader = db.reader(sql);


            while (reader.Read())
            {
                dgv.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString()); //添加一行
            }

            dgv.Columns[0].Visible = false;
            reader.Close();
            db.DataBaseClose();
        }

        private void FormOrder_Admin_Load(object sender, EventArgs e)
        {
            LoadOrder();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.CurrentRow == null || dgv.CurrentRow.Cells[0].Value == null)
            {
                MessageBox.Show("选中无效数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Oid = dgv.CurrentRow.Cells[0].Value.ToString(); //获取订单id
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Oid == null)
            {
                MessageBox.Show("未选中订单！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox1.Text == "")
            {
                MessageBox.Show("未选择订单状态！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataBase db = new DataBase();
            db.connect();
            string sql = $"update T_Order set state = '{comboBox1.Text}' WHERE Oid = '{Oid}'";
            if (db.Execute(sql) != 0)
            {
                MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.DataBaseClose(); //关闭数据库连接
                dgv.Rows.Clear(); //清空表格控件中的数据
                LoadOrder();
            }
            else
            {
                MessageBox.Show("修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                db.DataBaseClose(); //关闭数据库连接
            }
        }
    }
}
