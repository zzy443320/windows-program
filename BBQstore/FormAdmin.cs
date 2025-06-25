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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void 退出登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定要退出吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                //关闭当前窗口
                this.Close();
            }
        }

        //窗体加载的事件   双击窗体即可生成该函数
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            this.label1.Text = $"管理员：{Form1.name}  {Form1.id}";     //窗体生成的时候执行
        }

        //注销账号
        private void 注销账号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //提示
            if (DialogResult.Yes == MessageBox.Show("确定注销当前账号吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                //从数据库中删除数据
                string id = Form1.id;
                DataBase db = new DataBase();
                db.connect();
                string sql = $"delete T_Admin where AdminID = {id}";
                if (db.Execute(sql) > 0)
                {
                    //注销成功
                    MessageBox.Show("注销成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    db.DataBaseClose();
                    this.Close(); //关闭当前窗口
                }
                else
                {
                    //注销失败
                    MessageBox.Show("注销失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.DataBaseClose();
                }
            }
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUpdatePwd_Admin form = new FormUpdatePwd_Admin();
            form.ShowDialog();
        }

        private void 添加商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddGoods form = new FormAddGoods();
            form.ShowDialog();
        }

        private void 修改商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGoods_Manage form = new FormGoods_Manage();
            form.ShowDialog();  
        }

        private void 下架商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGoods_Manage form = new FormGoods_Manage();
            form.ShowDialog();
        }

        private void 搜索商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGoods_Manage form = new FormGoods_Manage();
            form.ShowDialog();
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUser_Manage form = new FormUser_Manage();
            form.ShowDialog();
        }

        private void 订单管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOrder_Admin form = new FormOrder_Admin();
            form.ShowDialog();
        }

        private void 用户评价管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdmin_comment form = new FormAdmin_comment();
            form.ShowDialog();
        }

        private void 消息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdmin_feedback form = new FormAdmin_feedback();
            form.ShowDialog();
        }
    }
}
