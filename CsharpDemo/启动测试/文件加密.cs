using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 启动测试
{
    public partial class 文件加密 : Form
    {
        public 文件加密()
        {
            InitializeComponent();
        }

        private void Encrypt_click(object sender, EventArgs e)
        {
            var source = 源地址.Text;
            var target = 目标地址.Text;
            using (var fRead = new FileStream(source, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (var fWriter = new FileStream(target, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    var bytes = new byte[1024 * 1024];
                    int num;
                    while ((num = fRead.Read(bytes, 0, bytes.Length)) > 0)
                    {
                        Thread.Sleep(100);
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            bytes[i] = (byte)(byte.MaxValue - bytes[i]);
                        }
                        fWriter.Write(bytes, 0, num);
                        进度条.Value = (int) (fWriter.Position * 100 / fRead.Length);
                    }

                    MessageBox.Show(text:"加密完成！", caption:"提示消息");
                }
            }
        }

        private void Decode_click(object sender, EventArgs e)
        {
            var source = 源地址.Text;
            var target = 目标地址.Text;
            using (var fRead = new FileStream(source, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (var fWriter = new FileStream(target, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    var bytes = new byte[1024 * 1024];
                    int num;
                    while ((num = fRead.Read(bytes, 0, bytes.Length)) > 0)
                    {
                        Thread.Sleep(100);
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            bytes[i] = (byte)(byte.MaxValue - bytes[i]);
                        }
                        fWriter.Write(bytes, 0, num);
                        进度条.Value = (int)(fWriter.Position * 100 / fRead.Length);
                    }

                    MessageBox.Show(text: "解密完成！", caption: "提示消息");
                }
            }
        }
    }
}
