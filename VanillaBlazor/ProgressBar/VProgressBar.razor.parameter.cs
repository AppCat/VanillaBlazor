using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 进度条的参数部分
    /// ProgressBar parameter partial
    /// </summary>
    public partial class VProgressBar
    {
        /// <summary>
        /// 当前进度
        /// </summary>
        [Parameter]
        public uint? Value { get; set; }

        /// <summary>
        /// 最大值
        /// </summary>
        [Parameter]
        public uint? MaxValue { get; set; }

        /// <summary>
        /// 进度条的外观。
        /// The appearance of the progress.
        /// </summary>
        [Parameter]
        public EnumMix<VProgressBarAppearance>? Appearance { get; set; }

        /// <summary>
        /// 进度条的 Bar 配置
        /// The bar is config for the progress.
        /// </summary>
        [Parameter]
        public VSonComponentConfig BarConfig { get; set; } = VSonComponentConfig.Empty;

        /// <summary>
        /// 当前进度变化
        /// </summary>
        [Parameter]
        public EventCallback<uint?> ValueChanged { get; set; }
    }
}
