using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 条带的参数部分
    /// The parameters section of the strip
    /// </summary>
    public partial class VStrip
    {
        /// <summary>
        /// 一个背景图像的strip。
        /// A background images for the strip.
        /// </summary>
        [Parameter]
        public string? Background { get; set; }

        /// <summary>
        /// 条带是否应该显示边框。
        /// Whether the strip should display borders.
        /// </summary>
        [Parameter]
        public bool Bordered { get; set; }

        /// <summary>
        /// 条带是否应该变暗。
        /// Whether the strip should be dark.
        /// </summary>
        [Parameter]
        public bool Dark { get; set; }

        /// <summary>
        /// 条带是否应深。
        /// Whether the strip should be deep.
        /// </summary>
        [Parameter]
        public bool Deep { get; set; }

        /// <summary>
        /// 条带是否应该轻。
        /// Whether the strip should be light.
        /// </summary>
        [Parameter]
        public bool Light { get; set; }

        /// <summary>
        /// 条带是否应浅。
        /// Whether the strip should be shallow.
        /// </summary>
        [Parameter]
        public bool Shallow { get; set; }

        /// <summary>
        /// 条带的类型。
        /// The type of the strip.
        /// </summary>
        [Parameter]
        public EnumMix<VStripType> Type { get; set; } = VStripType.Light;
    }
}
