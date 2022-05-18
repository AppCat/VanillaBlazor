using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 状态标签的参数部分
    /// The parameters section of the statusLabel
    /// </summary>
    public partial class VStatusLabel
    {
        /// <summary>
        /// 状态标签的外观。
        /// The status of the statusLabel.
        /// </summary>
        [Parameter]
        public EnumMix<VStatus>? Status { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        [Parameter]
        public string? Label { get; set; }
    }
}
