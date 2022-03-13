using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 列
    /// </summary>
    public interface IVColumn
    {
        /// <summary>
        /// 列号
        /// </summary>
        int ColumnIndex { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// 使用
        /// </summary>
        VColumUse Use { get; set; }
    }
}
