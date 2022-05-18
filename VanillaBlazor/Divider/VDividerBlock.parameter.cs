using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 分隔符的块的参数部分
    /// The parameters section of the dividerBlock
    /// </summary>
    public partial class VDividerBlock
    {
        #region CascadingParameter

        /// <summary>
        /// 组合上下文
        /// </summary>
        [CascadingParameter]
        protected CombineContext<VDivider, VDividerBlock> CombineContext { get; set; }

        /// <summary>
        /// 分隔符初始化
        /// </summary>
        [CascadingParameter(Name = "DividerInitialize")]
        protected bool DividerInitialize { get; set; }

        #endregion

        #region Parameter

        /// <summary>
        /// 块的标题。
        /// The title for the block.
        /// </summary>
        [Parameter]
        public string? Title { get; set; }

        /// <summary>
        /// 块的标题模板。
        /// The title is template for the block.
        /// </summary>
        [Parameter]
        public RenderFragment? TitleTemplate { get; set; }

        /// <summary>
        /// 块的 Title 配置
        /// The title is config for the block.
        /// </summary>
        [Parameter]
        public VSonComponentConfig TitleConfig { get; set; } = VSonComponentConfig.Empty;

        /// <summary>
        /// 块的内容。
        /// The content for the block.
        /// </summary>
        [Parameter]
        public string? Content { get; set; }

        /// <summary>
        /// 块的内容模板。
        /// The content is template for the block.
        /// </summary>
        [Parameter]
        public RenderFragment? ContentTemplate { get; set; }

        /// <summary>
        /// 块的 Content 配置
        /// The content is config for the block.
        /// </summary>
        [Parameter]
        public VSonComponentConfig ContentConfig { get; set; } = VSonComponentConfig.Empty;

        #endregion
    }
}
