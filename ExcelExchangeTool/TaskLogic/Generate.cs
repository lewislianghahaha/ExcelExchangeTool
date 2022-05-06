using System;
using System.Data;
using ExcelExchangeTool.DB;

namespace ExcelExchangeTool.TaskLogic
{
    //运算
    public class Generate
    {
        DtTemp dtTemp=new DtTemp();

        //保存中转记录的临时表
        public DataTable tempdt;

        /// <summary>
        /// 运算
        /// </summary>
        /// <param name="sourcedt"></param>
        /// <returns></returns>
        public DataTable GenerateDt(DataTable sourcedt)
        {
            //创建导出临时表
            var resultdt = dtTemp.Get_Exportdt();
            //
            for (var i = 0; i < sourcedt.Rows.Count; i++)
            {
                //将id=11~34的色母记录放到Tempdt
                tempdt = GetColorantDt(sourcedt.Rows[i]);
                //
                for (var id = 0; id < tempdt.Rows.Count; id++)
                {
                    var newrow = resultdt.NewRow();
                    newrow[0] = id == 0 ? (object) Convert.ToString(sourcedt.Rows[i][0]) : DBNull.Value;  //制造商
                    newrow[1] = id == 0 ? (object)Convert.ToString(sourcedt.Rows[i][1]) : DBNull.Value;   //车型
                    newrow[2] = id == 0 ? (object)Convert.ToString(sourcedt.Rows[i][2]) : DBNull.Value;   //涂层
                    newrow[3] = id == 0 ? (object)Convert.ToString(sourcedt.Rows[i][3]) : DBNull.Value;   //颜色描述
                    newrow[4] = id == 0 ? (object)Convert.ToString(sourcedt.Rows[i][4]) : DBNull.Value;   //内部色号
                    newrow[5] = id == 0 ? (object)Convert.ToString(sourcedt.Rows[i][5]) : DBNull.Value;   //主配方色号(差异色)
                    newrow[6] = id == 0 ? (object)Convert.ToString(sourcedt.Rows[i][6]) : DBNull.Value;   //颜色组别
                    newrow[7] = id == 0 ? (object)Convert.ToString(sourcedt.Rows[i][7]) : DBNull.Value;   //标准色号
                    newrow[8] = id == 0 ? (object)Convert.ToString(sourcedt.Rows[i][8]) : DBNull.Value;   //RGBValue
                    newrow[9] = id == 0 ? (object)Convert.ToString(sourcedt.Rows[i][9]) : DBNull.Value;   //版本日期
                    newrow[10] = id == 0 ? (object)Convert.ToString(sourcedt.Rows[i][10]) : DBNull.Value; //层
                    newrow[11] = Convert.ToString(tempdt.Rows[id][0]);                                    //色母编码
                    newrow[12] = Convert.ToString(tempdt.Rows[id][1]);                                    //色母名称
                    newrow[13] = Convert.ToDecimal(tempdt.Rows[id][2]);                                   //色母量(克)
                    newrow[14] = DBNull.Value;                                         //累积量(可不填)
                    newrow[15] = id == 0 ? (object)Convert.ToString(sourcedt.Rows[i][36]) : DBNull.Value; //制作人
                    newrow[16] = id == 0 ? (object)Convert.ToString(sourcedt.Rows[i][37]) : DBNull.Value; //备注
                    newrow[17] = id == 0 ? (object)Convert.ToString(sourcedt.Rows[i][38]) : DBNull.Value; //信息说明
                    resultdt.Rows.Add(newrow);
                }
                //每行结束后将Temp记录删除
                tempdt.Rows.Clear();
                tempdt.Columns.Clear();
            }
            return resultdt;
        }

        /// <summary>
        /// 根据每行获取对应的色母记录(重)
        /// </summary>
        /// <returns></returns>
        private DataTable GetColorantDt(DataRow rows)
        {
            var dt = dtTemp.TempDt();

            //j为获取rows的下标值(11~34)
            for (var j = 11; j < 35; j++)
            {
                //当碰到‘色母编码’为空即跳过,但j继续自增
                if (Convert.ToString(rows[j + 0]) == "")
                {
                    j++;//j下标值自增1(重)
                    continue;
                }
                else
                {
                    var newrow = dt.NewRow();
                    newrow[0] = Convert.ToString(rows[j + 0]);       //色母编码
                    newrow[1] = DBNull.Value;                        //色母名称
                    newrow[2] = Convert.ToString(rows[j + 0 + 1]) == ""
                        ? (object)DBNull.Value : Convert.ToDecimal(rows[j + 0 + 1]);      //色母量(克)
                    dt.Rows.Add(newrow);
                    j++;  //j下标值自增1(重)
                }
            }
            return dt;
        }

    }
}
