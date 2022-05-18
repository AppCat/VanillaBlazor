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
    /// 炸薯条的参数部分
    /// Chip parameter partial
    /// </summary>
    public partial class VChip
    {
        /// <summary>
        /// 炸薯条的外观。
        /// The appearance of the chip.
        /// </summary>
        [Parameter]
        public EnumMix<VAppearance>? Appearance { get; set; }

        /// <summary>
        /// 炸薯条的前缀。
        /// The lead for the chip.
        /// </summary>
        [Parameter]
        public string? Lead { get; set; }

        /// <summary>
        /// 炸薯条的前缀模板。
        /// The lead is template for the chip.
        /// </summary>
        [Parameter]
        public RenderFragment? LeadTemplate { get; set; }

        /// <summary>
        /// 炸薯条的前缀
        /// The lead is config for the chip.
        /// </summary>
        [Parameter]
        public VSonComponentConfig LeadConfig { get; set; } = VSonComponentConfig.Empty;

        /// <summary>
        /// 炸薯条的内容。
        /// The value for the chip.
        /// </summary>
        [Parameter]
        public string? Value { get; set; }

        /// <summary>
        /// 炸薯条的内容模板。
        /// The value is template for the chip.
        /// </summary>
        [Parameter]
        public RenderFragment? ValueTemplate { get; set; }

        /// <summary>
        /// 炸薯条的内容的配置
        /// The value is config for the chip.
        /// </summary>
        [Parameter]
        public VSonComponentConfig ValueConfig { get; set; } = VSonComponentConfig.Empty;

        /// <summary>
        /// 炸薯条是否被选中。
        /// Whether the chip is selected.
        /// </summary>
        [Parameter]
        public bool Selected { get; set; }

        /// <summary>
        /// 炸薯条是否应该有密集的填充。
        /// Whether the chip should have dense padding.
        /// </summary>
        [Parameter]
        public bool Dense { get; set; }

        /// <summary>
        /// 炸薯条是否内联显示。
        /// Whether the chip should display inline.
        /// </summary>
        [Parameter]
        public bool Inline { get; set; }

        /// <summary>
        /// 炸薯条是否应该小。
        /// Whether the chip should be small.
        /// </summary>
        [Parameter]
        public bool Small { get; set; }

        /// <summary>
        /// 炸薯条是否应该被暗黑化。
        /// Whether the chip should be dark.
        /// </summary>
        [Parameter]
        public bool Dark { get; set; }

        /// <summary>
        /// 点击事件
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <summary>
        /// 关闭事件
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnDismiss { get; set; }

        /// <summary>
        /// 点击停止传播
        /// </summary>
        [Parameter]
        public bool? OnClickStopPropagation { get; set; }
    }
}
