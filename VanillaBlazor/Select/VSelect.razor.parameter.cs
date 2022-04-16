using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 这是一个用于Select组件的参数部分.
    /// This is a parameter section for the Select component
    /// </summary>
    public partial class VSelect
    {
        /// <summary>
        /// 提示信息
        /// </summary>
        [Parameter]
        public string? Placeholder { get; set; }
    }
}
