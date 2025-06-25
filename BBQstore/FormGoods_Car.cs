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
using System.Xml.Linq;

namespace BBQstore
{
    public partial class FormGoods_Car : Form
    {
        public FormGoods_Car()
        {
            InitializeComponent();
        }

        private void LoadCar()
        {
            int cid = FormGoods_Select.cid;
            DataBase db = new DataBase();
            db.connect(); //连接数据库
            string sql = $"select * from T_CarItem where Cid = {cid}"; //查询所有商品信息
            SqlDataReader reader = db.reader(sql);

            while (reader.Read())
            {
                dgv.Rows.Add(reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),
                    reader[4].ToString(), reader[5].ToString(), reader[6].ToString()); //添加一行
            }
            reader.Close();
            db.DataBaseClose();
        }

        private void FormGoods_Car_Load(object sender, EventArgs e)
        {
            LoadCar(); //加载购物车商品信息
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            int cid = FormGoods_Select.cid;
            DataBase db = new DataBase();
            db.connect();

            string sql = $"delete from T_CarItem where Cid = {cid}";
            if(db.Execute(sql) >0)
            {
                MessageBox.Show("清除成功，请重新挑选商品！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.DataBaseClose();
                dgv.Rows.Clear();
            }
            else 
            {
                MessageBox.Show("清除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                db.DataBaseClose();
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            string id = Form1.id;
            float sum = FormGoods_Select.sum;
            DataBase db = new DataBase();
            db.connect();
            string sql = $"insert into T_Order (uid, Pay, state) values('{id}', '{sum}', '待支付')";
            if (db.Execute(sql) > 0)
            {
                MessageBox.Show("下单成功，可前往我的订单中查看！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.DataBaseClose();
            }
            else
            {
                MessageBox.Show("下单失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.DataBaseClose();
            }
        }
    }
}
