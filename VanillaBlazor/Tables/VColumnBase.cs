using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 数据表列基础
    /// The underlying column of a table
    /// </summary>
    public abstract class VColumnBase : VContentComponentBase, IVColumn
    {
        /// <summary>
        /// 列上下文
        /// </summary>
        [CascadingParameter]
        protected VColumnContext<IVColumn> ColumnContext { get; set; }

        /// <summary>
        /// 是否初始化
        /// </summary>
        [CascadingParameter(Name = "TableInitialize")]
        protected bool IsInitialize { get; set; }

        /// <summary>
        /// 使用
        /// </summary>
        [CascadingParameter]
        public VColumUse Use { get; set; }

        /// <summary>
        /// 列序号
        /// </summary>
        [Parameter]
        public int ColumnIndex { get; set; }

        /// <summary>+
        /// 标题
        /// </summary>
        [Parameter]
        public string Title { get; set; }

        /// <summary>
        /// 标题模板
        /// </summary>
        [Parameter]
        public RenderFragment TitleTemplate { get; set; }

        /// <summary>
        /// 标题配置
        /// </summary>
        [Parameter]
        public VSonComponentConfig TitleConfig { get; set; }
    }
}
