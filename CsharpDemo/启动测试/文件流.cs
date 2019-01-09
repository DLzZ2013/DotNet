using System;
using 文件流;
using System.Windows.Forms;

namespace 启动测试
{
    public partial class 文件流 : Form
    {
        public 文件流()
        {
            InitializeComponent();
        }

        private void 文件复制_click(object sender, EventArgs e)
        {
           
        }

        private void 文件加密_click(object sender, EventArgs e)
        {
            Visible = false;
            文件加密 fileEncrypt = new 文件加密();
            fileEncrypt.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str2 = StreamWriter和StreamReader.Writer();
            string str1 = StreamWriter和StreamReader.Read();
           
            MessageBox.Show(str1+@"\r\n"+str2);
        }
    }
}
