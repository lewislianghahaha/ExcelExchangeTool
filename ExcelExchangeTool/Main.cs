using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using ExcelExchangeTool.TaskLogic;

namespace ExcelExchangeTool
{
    public partial class Main : Form
    {
        Logic taskLogic=new Logic();
        Load load=new Load();

        /// <summary>
        /// 保存运算后得出的DT
        /// </summary>
        private DataTable _exportdt;

        public Main()
        {
            InitializeComponent();
            OnRegisterEvents();
        }

        private void OnRegisterEvents()
        {
            tmclose.Click += Tmclose_Click;
            btnimport.Click += Btnimport_Click;
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btnimport_Click(object sender, EventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog { Filter = $"Xlsx文件|*.xlsx" };
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;
                var fileAdd = openFileDialog.FileName;

                //所需的值赋到Task类内
                taskLogic.TaskId = 0;
                taskLogic.FileAddress = fileAdd;

                //使用子线程工作(作用:通过调用子线程进行控制Load窗体的关闭情况)
                new Thread(Start).Start();
                load.StartPosition = FormStartPosition.CenterScreen;
                load.ShowDialog();

                var importdt = taskLogic.ResultTable;

                if(importdt.Rows.Count==0) throw new Exception("不能成功导入EXCEL内容,请检查模板是否正确.");
                else
                {
                    var clickMessage = $"导入成功,是否进行运算功能?";
                    var clickMes = $"运算成功,是否进行导出至Excel?";

                    if (MessageBox.Show(clickMessage, $"提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (!Generatedt(importdt)) throw new Exception("运算结果没有记录,请检查是否与实际情况一致");
                        else if (MessageBox.Show(clickMes, $"提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            Exportdt();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, $"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 运算功能
        /// </summary>
        /// <param name="importdt"></param>
        /// <returns></returns>
        bool Generatedt(DataTable importdt)
        {
            var result = true;

            try
            {
                taskLogic.TaskId = 1;
                taskLogic.Data = importdt.Copy();

                //使用子线程工作(作用:通过调用子线程进行控制Load窗体的关闭情况)
                new Thread(Start).Start();
                load.StartPosition = FormStartPosition.CenterScreen;
                load.ShowDialog();

                if (taskLogic.ResultTable.Rows.Count == 0) result = false;
                else
                {
                    _exportdt = taskLogic.ResultTable.Copy();
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 导出功能
        /// </summary>
        void Exportdt()
        {
            var saveFileDialog = new SaveFileDialog { Filter = $"Xlsx文件|*.xlsx" };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var fileAdd = saveFileDialog.FileName;

            taskLogic.TaskId = 2;
            taskLogic.FileAddress = fileAdd;
            taskLogic.ExportDt = _exportdt;

            //使用子线程工作(作用:通过调用子线程进行控制Load窗体的关闭情况)
            new Thread(Start).Start();
            load.StartPosition = FormStartPosition.CenterScreen;
            load.ShowDialog();

            if (!taskLogic.ResultMark) throw new Exception("导出异常");
            else
            {
                MessageBox.Show($"导出成功!可从EXCEL中查阅导出效果", $"成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        ///子线程使用(重:用于监视功能调用情况,当完成时进行关闭LoadForm)
        /// </summary>
        private void Start()
        {
            taskLogic.StartTask();

            //当完成后将Form2子窗体关闭
            this.Invoke((ThreadStart)(() => {
                load.Close();
            }));
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tmclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
