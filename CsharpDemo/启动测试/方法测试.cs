using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 启动测试
{
    public partial class 方法测试 : Form
    {
        public 方法测试()
        {
            InitializeComponent();
        }

        private void 文件流_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            var fileStream = new 文件流();
            fileStream.ShowDialog();
        }
      
        private void GZip_Click(object sender, EventArgs e)
        {

        }
    }
}
