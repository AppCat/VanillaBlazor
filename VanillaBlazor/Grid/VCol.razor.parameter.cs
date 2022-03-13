using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 列的参数部分
    /// Col parameter partial
    /// </summary>
    public partial class VCol
    {
        /// <summary>
        /// 用来代替的可选元素或组件。
        /// Optional element or component to use instead.
        /// </summary>
        [Parameter]
        public EnumMix<VOptionalElement>? Element { get; set; }

        /// <summary>
        /// 在大屏幕上开始之前要跳过的列数。  
        /// The number of columns to skip before starting on large screens.
        /// </summary>
        [Parameter]
        public EnumMix<VColSize>? EmptyLarge { get; set; }

        /// <summary>
        /// 在开始中屏幕前要跳过的列数。
        /// The number of columns to skip before starting on medium screens.
        /// </summary>
        [Parameter]
        public EnumMix<VColSize>? EmptyMedium { get; set; }

        /// <summary>
        /// 在小屏幕上开始之前要跳过的列数。
        /// The number of columns to skip before starting on small screens.
        /// </summary>
        [Parameter]
        public EnumMix<VColSize>? EmptySmall { get; set; }

        /// <summary>
        /// 覆盖内容在大屏幕上占据的列数。  
        /// Override for the number of columns the content occupies on large screens.
        /// </summary>
        [Parameter]
        public EnumMix<VColSize>? Large { get; set; }

        /// <summary>
        /// 覆盖内容在中屏幕上占据的列数。 
        /// Override for the number of columns the content occupies on medium screens.
        /// </summary>
        [Parameter]
        public EnumMix<VColSize>? Medium { get; set; }

        /// <summary>
        /// 覆盖内容在小屏幕上占据的列数。
        /// Override for the number of columns the content occupies on small screens.
        /// </summary>
        [Parameter]
        public EnumMix<VColSize>? Small { get; set; }

        /// <summary>
        /// 内容占据的列数。
        /// The number of columns the content occupies.
        /// </summary>
        [Parameter]
        public EnumMix<VColSize>? Size { get; set; }
    }
}
