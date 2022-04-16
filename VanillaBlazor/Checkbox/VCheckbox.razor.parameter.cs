using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 这是一个用于Checkbox组件的参数部分.
    /// This is a parameter section for the checkbox component
    /// </summary>
    public partial class VCheckbox
    {
        /// <summary>
        /// 标签
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// Checkbox的 Label 配置
        /// The label is config for the checkbox.
        /// </summary>
        [Parameter]
        public VSonComponentConfig LabelConfig { get; set; } = VSonComponentConfig.Empty;

        /// <summary>
        /// 检查
        /// </summary>
        [Parameter]
        public bool Checked { get; set; }

        /// <summary>
        /// Gets or sets a callback that updates the bound checked.
        /// </summary>
        [Parameter]
        public virtual EventCallback<bool> CheckedChanged { get; set; }

        /// <summary>
        /// 变化事件
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnCheckedChange { get; set; }
    }
}
