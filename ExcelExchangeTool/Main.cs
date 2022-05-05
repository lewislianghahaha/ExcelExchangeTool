using System.Windows.Forms;

namespace ExcelExchangeTool
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            OnRegisterEvents();
        }

        private void OnRegisterEvents()
        {
            tmclose.Click += Tmclose_Click;
            btnimport.Click += Btnimport_Click;
            llink.Click += Llink_Click;
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btnimport_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 导入模板下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Llink_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }


        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tmclose_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
