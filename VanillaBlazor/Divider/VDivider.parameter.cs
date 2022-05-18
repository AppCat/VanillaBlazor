using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 分隔符的参数部分
    /// The parameters section of the divider
    /// </summary>
    public partial class VDivider
    {
        /// <summary>
        /// 暗系
        /// </summary>
        [Parameter]
        public bool Dark { get; set; }
    }
}
