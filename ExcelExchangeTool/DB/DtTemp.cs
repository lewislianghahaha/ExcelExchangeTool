﻿using System;
using System.Data;

namespace ExcelExchangeTool.DB
{
    //临时表
    public class DtTemp
    {
        /// <summary>
        /// 导入模板(横向)
        /// </summary>
        /// <returns></returns>
        public DataTable Get_Importdt()
        {
            var dt = new DataTable();
            for (var i = 0; i < 39; i++)
            {
                var dc = new DataColumn();

                switch (i)
                {
                    case 0:
                        dc.ColumnName = "制造商";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 1:
                        dc.ColumnName = "车型";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 2:
                        dc.ColumnName = "涂层";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 3:
                        dc.ColumnName = "颜色描述";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 4:
                        dc.ColumnName = "内部色号";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 5:
                        dc.ColumnName = "主配方(差异色)";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 6:
                        dc.ColumnName = "颜色组别";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 7:
                        dc.ColumnName = "标准色号";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 8:
                        dc.ColumnName = "RGBValue";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 9:
                        dc.ColumnName = "版本日期";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 10:
                        dc.ColumnName = "层";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 11:
                        dc.ColumnName = "色母1";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 12:
                        dc.ColumnName = "色母量1";
                        dc.DataType = Type.GetType("System.Decimal");
                        break;
                    case 13:
                        dc.ColumnName = "色母2";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 14:
                        dc.ColumnName = "色母量2";
                        dc.DataType = Type.GetType("System.Decimal");
                        break;
                    case 15:
                        dc.ColumnName = "色母3";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 16:
                        dc.ColumnName = "色母量3";
                        dc.DataType = Type.GetType("System.Decimal");
                        break;
                    case 17:
                        dc.ColumnName = "色母4";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 18:
                        dc.ColumnName = "色母量4";
                        dc.DataType = Type.GetType("System.Decimal");
                        break;
                    case 19:
                        dc.ColumnName = "色母5";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 20:
                        dc.ColumnName = "色母量5";
                        dc.DataType = Type.GetType("System.Decimal");
                        break;
                    case 21:
                        dc.ColumnName = "色母6";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 22:
                        dc.ColumnName = "色母量6";
                        dc.DataType = Type.GetType("System.Decimal");
                        break;
                    case 23:
                        dc.ColumnName = "色母7";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 24:
                        dc.ColumnName = "色母量7";
                        dc.DataType = Type.GetType("System.Decimal");
                        break;
                    case 25:
                        dc.ColumnName = "色母8";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 26:
                        dc.ColumnName = "色母量8";
                        dc.DataType = Type.GetType("System.Decimal");
                        break;
                    case 27:
                        dc.ColumnName = "色母9";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 28:
                        dc.ColumnName = "色母量9";
                        dc.DataType = Type.GetType("System.Decimal");
                        break;
                    case 29:
                        dc.ColumnName = "色母10";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 30:
                        dc.ColumnName = "色母量10";
                        dc.DataType = Type.GetType("System.Decimal");
                        break;
                    case 31:
                        dc.ColumnName = "色母11";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 32:
                        dc.ColumnName = "色母量11";
                        dc.DataType = Type.GetType("System.Decimal");
                        break;
                    case 33:
                        dc.ColumnName = "色母12";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 34:
                        dc.ColumnName = "色母量12";
                        dc.DataType = Type.GetType("System.Decimal");
                        break;
                    case 35:
                        dc.ColumnName = "累积量";
                        dc.DataType = Type.GetType("System.Decimal");
                        break;
                    case 36:
                        dc.ColumnName = "制作人";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 37:
                        dc.ColumnName = "备注";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 38:
                        dc.ColumnName = "信息说明";
                        dc.DataType = Type.GetType("System.String");
                        break;
                }
                dt.Columns.Add(dc);
            }
            return dt;
        }

        /// <summary>
        /// 导出模板(纵向)
        /// </summary>
        /// <returns></returns>
        public DataTable Get_Exportdt()
        {
            var dt = new DataTable();
            for (var i = 0; i < 18; i++)
            {
                var dc = new DataColumn();

                switch (i)
                {
                    case 0:
                        dc.ColumnName = "制造商";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 1:
                        dc.ColumnName = "车型";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 2:
                        dc.ColumnName = "涂层";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 3:
                        dc.ColumnName = "颜色描述";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 4:
                        dc.ColumnName = "内部色号";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 5:
                        dc.ColumnName = "主配方(差异色)";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 6:
                        dc.ColumnName = "颜色组别";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 7:
                        dc.ColumnName = "标准色号";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 8:
                        dc.ColumnName = "RGBValue";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 9:
                        dc.ColumnName = "版本日期";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 10:
                        dc.ColumnName = "层";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 11:
                        dc.ColumnName = "色母编码";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 12:
                        dc.ColumnName = "色母名称";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 13:
                        dc.ColumnName = "色母量(克)";
                        dc.DataType = Type.GetType("System.Decimal");
                        break;
                    case 14:
                        dc.ColumnName = "累积量(可不填)";
                        dc.DataType = Type.GetType("System.Decimal");
                        break;
                    case 15:
                        dc.ColumnName = "制作人";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 16:
                        dc.ColumnName = "备注";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 17:
                        dc.ColumnName = "信息说明";
                        dc.DataType = Type.GetType("System.String");
                        break;
                }
                dt.Columns.Add(dc);
            }
            return dt;
        }

        /// <summary>
        /// 临时表-记录色母相信息
        /// </summary>
        /// <returns></returns>
        public DataTable TempDt()
        {
            var dt = new DataTable();
            for (var i = 0; i < 3; i++)
            {
                var dc = new DataColumn();

                switch (i)
                {
                    case 0:
                        dc.ColumnName = "色母编码";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 1:
                        dc.ColumnName = "色母名称";
                        dc.DataType = Type.GetType("System.String");
                        break;
                    case 2:
                        dc.ColumnName = "色母量(克)";
                        dc.DataType = Type.GetType("System.Decimal");
                        break;
                }
                dt.Columns.Add(dc);
            }
            return dt;
        }

    }
}
