using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 列上下文
    /// </summary>
    /// <typeparam name="TColumn"></typeparam>
    public class VColumnContext<TColumn>
        where TColumn : IVColumn
    {
        /// <summary>
        /// 组件集
        /// </summary>
        public IList<TColumn> Columns { get; set; } = new List<TColumn>();

        /// <summary>
        /// 当前列号
        /// </summary>
        public int CurrentColumnIndex { get; set; }

        /// <summary>
        /// 添加列
        /// </summary>
        /// <param name="column"></param>
        public void AddColumn(TColumn column)
        {
            if (column == null)
            {
                return;
            }
            column.ColumnIndex = CurrentColumnIndex++;
            Columns.Add(column);
        }
    }
}
