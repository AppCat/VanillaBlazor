using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 模态组件
    /// </summary>
    public class VModalActionModalConfig : VSonComponentConfig
    {
        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 按钮的外观。
        /// The appearance of the button.
        /// </summary>
        public EnumMix<VButtonAppearance>? Appearance { get; set; }

        /// <summary>
        /// 点击
        /// </summary>
        public Func<object, Task<bool>> OnClick { get; set; }
    }
}
