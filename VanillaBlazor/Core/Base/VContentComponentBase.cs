using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 内容组件基础
    /// </summary>
    public class VContentComponentBase : VComponentBase
    {
        /// <summary>
        /// 子内容
        /// </summary>
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }

    /// <summary>
    /// 内容组件基础
    /// </summary>
    public class VContentComponentBase<TContext> : VComponentBase
    {
        /// <summary>
        /// 子内容
        /// </summary>
        [Parameter]
        public RenderFragment<TContext>? ChildContent { get; set; }
    }
}
