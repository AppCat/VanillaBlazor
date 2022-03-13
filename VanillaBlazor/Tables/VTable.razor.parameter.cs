using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 数据表的参数部分
    /// Table parameter partial
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public partial class VTable<TModel>
    {
        /// <summary>
        /// 单元格过滤器
        /// </summary>
        [Parameter]
        public Func<TModel, bool> RowFilter { get; set; }

        /// <summary>
        /// 数据源
        /// </summary>
        [Parameter]
        public IEnumerable<TModel> DataSource { get; set; }

        /// <summary>
        /// 隐藏表头
        /// </summary>
        [Parameter]
        public bool HideHeader { get; set; }
    }
}
