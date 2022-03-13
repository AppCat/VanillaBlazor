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
    /// 按钮的参数部分
    /// Buttons parameter partial
    /// </summary>
    public partial class VButton
    {
        /// <summary>
        /// 按钮的外观。
        /// The appearance of the button.
        /// </summary>
        [Parameter]
        public EnumMix<VButtonAppearance>? Appearance { get; set; }

        /// <summary>
        /// 用来代替按钮的可选元素或组件。
        /// Optional element or component to use instead of button.
        /// </summary>
        [Parameter]
        public EnumMix<VOptionalElement>? Element { get; set; }

        /// <summary>
        /// 按钮是否应该有密集的填充。
        /// Whether the button should have dense padding.
        /// </summary>
        [Parameter]
        public bool Dense { get; set; }

        /// <summary>
        /// 按钮的内容中是否有图标。
        /// Whether the button has an icon in the content.
        /// </summary>
        [Parameter]
        public bool HasIcon { get; set; }

        /// <summary>
        /// 按钮是否内联显示。
        /// Whether the button should display inline.
        /// </summary>
        [Parameter]
        public bool Inline { get; set; }

        /// <summary>
        /// 按钮是否应该小。
        /// Whether the button should be small.
        /// </summary>
        [Parameter]
        public bool Small { get; set; }

        /// <summary>
        /// 按钮是否应进行处理。
        /// Whether the button should be processing.
        /// </summary>
        [Parameter]
        public bool Processing { get; set; }

        /// <summary>
        /// 按钮是否应该被主题化。
        /// Whether the button should be theming.
        /// </summary>
        [Parameter]
        public bool Theming { get; set; }

        /// <summary>
        /// 点击事件
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <summary>
        /// 点击停止传播
        /// </summary>
        [Parameter]
        public bool? OnClickStopPropagation { get; set; }

        /// <summary>
        /// 处理事件用于 Bind。
        /// Processing event use for bind.
        /// </summary>
        [Parameter]
        public EventCallback<bool> ProcessingChanged { get; set; }
    }
}
