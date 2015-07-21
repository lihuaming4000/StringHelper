using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolHelper
{
    public static class StringTool
    {
        /// <summary>
        /// 日期格式转换
        /// </summary>
        /// <param name="sourceObj">源数据</param>
        /// <param name="dataFormat">格式化字符串</param>
        /// <returns></returns>
        public static string ToDate(this object sourceObj, string dataFormat)
        {
            DateTime temp = DateTime.Now;

            DateTime.TryParse(sourceObj.ToString(), out temp);

            return temp.ToString(dataFormat);
        }

        /// <summary>
        /// 日期格式转换 yyyy-MM-dd 指定格式
        /// </summary>
        /// <param name="sourceObj"></param>
        /// <returns></returns>
        public static string ToDate(this object sourceObj)
        {
            return ToDate(sourceObj, "yyyy-MM-dd");
        }

        /// <summary>
        /// 截断 字符串 指定长度
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <param name="length">字节长度</param>
        /// <returns></returns>
        public static string Cut(this string sourceStr, int length)
        {
            if (sourceStr.Length > length)
                return sourceStr.Substring(0, length);
            else
                return sourceStr;
        }

        /// <summary>
        /// 截断 字符串18位
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <returns></returns>
        public static string Cut18(this string sourceStr)
        {
            return Cut(sourceStr, 18);
        }

        /// <summary>
        /// 截断 字符串
        /// </summary>
        /// <param name="sourceObj"></param>
        /// <returns></returns>
        public static string Cut(this object sourceObj)
        {
            return Cut(sourceObj.ToString(), 18);
        }

        /// <summary>
        /// 截断 字符串
        /// </summary>
        /// <param name="sourceObj"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Cut(this object sourceObj, int length)
        {
            return Cut(sourceObj.ToString(), length);
        }

        /// <summary>
        /// 截断带有html 字符的文本,并返回纯文字
        /// </summary>
        /// <param name="sourceObj"></param>
        /// <returns></returns>
        public static string CutHtml(this object sourceObj)
        {
            var _tmpStr = sourceObj.FilterOutHtml();

            return Cut(_tmpStr, 30);
        }

        /// <summary>
        /// 截取带有html字符文本的指定长度,并返回纯文字.
        /// </summary>
        /// <param name="sourceObj"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CutHtml(this object sourceObj, int length)
        {
            var _tmpStr = sourceObj.FilterOutHtml();

            return Cut(_tmpStr, length);
        }

        /// <summary>
        /// 过滤html字符串
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public static string FilterOutHtml(this object Htmlstring)
        {
            var _tmpStr = Htmlstring.ToString().Trim();

            if (_tmpStr.Length > 0)
            {
                //去除HTML标签
                _tmpStr = System.Text.RegularExpressions.Regex.Replace(_tmpStr, "<[^>]+>", "");

                //去除特殊符号
                _tmpStr = System.Text.RegularExpressions.Regex.Replace(_tmpStr, "&[^;]+;", "");

                //保留中文字，英文，中英文标点
                //_tmpStr = System.Text.RegularExpressions.Regex.Replace(_tmpStr, @"[^\u4E00-\u9FA5\，\。\,\.a-zA-Z0-9]", "");

            }
            return _tmpStr.Trim().Replace("'", "’");
        }

        /// <summary>
        /// 文本转数值
        /// </summary>
        /// <param name="sourceObj"></param>
        /// <returns></returns>
        public static int ToInt(this string sourceObj)
        {
            int temp = 0;

            int.TryParse(sourceObj, out temp);

            return temp;
        }

        /// <summary>
        /// 日期转中文
        /// </summary>
        /// <param name="dow"></param>
        /// <returns></returns>
        public static string TransDayOfWeek(this DayOfWeek dow)
        {
            switch (dow)
            {
                case DayOfWeek.Friday:
                    return "周五";
                case DayOfWeek.Monday:
                    return "周一";
                case DayOfWeek.Saturday:
                    return "周六";
                case DayOfWeek.Sunday:
                    return "周日";
                case DayOfWeek.Thursday:
                    return "周四";
                case DayOfWeek.Tuesday:
                    return "周二";
                case DayOfWeek.Wednesday:
                    return "周三";
                default:
                    return " ";
            }
        }

        /// <summary>
        /// 日期转英文短
        /// </summary>
        /// <param name="dow"></param>
        /// <returns></returns>
        public static string TransDayOfWeekShot(this DayOfWeek dow)
        {
            switch (dow)
            {
                case DayOfWeek.Friday:
                    return "Fri";
                case DayOfWeek.Monday:
                    return "Mon";
                case DayOfWeek.Saturday:
                    return "Sat";
                case DayOfWeek.Sunday:
                    return "Sun";
                case DayOfWeek.Thursday:
                    return "Thur";
                case DayOfWeek.Tuesday:
                    return "Tues";
                case DayOfWeek.Wednesday:
                    return "Wed";
                default:
                    return " ";
            }
        }
    }
}
