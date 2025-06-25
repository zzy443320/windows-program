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
    public partial class FormUser : Form
    {
        public FormUser()
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

        private void FormUser_Load(object sender, EventArgs e)
        {
            this.label1.Text = $"顾客：{Form1.name}  {Form1.id}";
        }

        private void 注销账号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //提示
            if (DialogResult.Yes == MessageBox.Show("确定注销当前账号吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                //从数据库中删除数据
                string id = Form1.id;
                DataBase db = new DataBase();
                db.connect();
                string sql = $"delete T_User where [Uid] = {id}";
                if(db.Execute(sql) > 0)
                {
                    //注销成功
                    MessageBox.Show("注销成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    db. DataBaseClose();
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
            FormUpdatePwd_User form = new FormUpdatePwd_User();
            form.ShowDialog();
        }

        private void 购物车管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGoods_Select form = new FormGoods_Select();
            form.ShowDialog();
        }

        private void 个人信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 查看评价ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUser_comment form = new FormUser_comment();
            form.ShowDialog();
        }

        private void 订单管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOrder_User form = new FormOrder_User();
            form.ShowDialog();
        }

        private void 反馈到管理员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUser_feedback form = new FormUser_feedback();
            form.ShowDialog();
        }
    }
}
