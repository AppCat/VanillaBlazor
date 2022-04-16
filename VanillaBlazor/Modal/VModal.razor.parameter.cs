using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 模态组件的参数部分
    /// Modal parameter partial
    /// </summary>
    public partial class VModal : IVModalConfig
    {
        /// <summary>
        /// 模态的 Header 配置
        /// The header is config for the modal.
        /// </summary>
        [Parameter]
        public VSonComponentConfig HeaderConfig { get; set; } = VSonComponentConfig.Empty;

        /// <summary>
        /// 传递的模型
        /// Model of transfer
        /// </summary>
        [Parameter]
        public object Model { get; set; }

        /// <summary>
        /// 模态的标题。
        /// The title for the modal.
        /// </summary>
        [Parameter]
        public string? Title { get; set; }

        /// <summary>
        /// 模态的标题模板。
        /// The title is template for the modal.
        /// </summary>
        [Parameter]
        public RenderFragment<object>? TitleTemplate { get; set; }

        /// <summary>
        /// 模态的 Title 配置
        /// The title is config for the modal.
        /// </summary>
        [Parameter]
        public VSonComponentConfig TitleConfig { get; set; } = VSonComponentConfig.Empty;

        /// <summary>
        /// 模态的内容。
        /// The content for the modal.
        /// </summary>
        [Parameter]
        public string? Content { get; set; }

        /// <summary>
        /// 模态的内容模板。
        /// The content is template for the modal.
        /// </summary>
        [Parameter]
        public RenderFragment<object>? ContentTemplate { get; set; }

        /// <summary>
        /// 模态的 Content 配置
        /// The content is config for the modal.
        /// </summary>
        [Parameter]
        public VSonComponentConfig ContentConfig { get; set; } = VSonComponentConfig.Empty;

        /// <summary>
        /// 行为
        /// </summary>
        [Parameter]
        public VModalActionModalConfig[] Actions { get; set; } = new VModalActionModalConfig[0];

        /// <summary>
        /// 模态的内容模板。
        /// The content is template for the modal.
        /// </summary>
        [Parameter]
        public RenderFragment<object>? FooterTemplate { get; set; }

        /// <summary>
        /// 模态的 Footer 配置
        /// The footer is config for the modal.
        /// </summary>
        [Parameter]
        public VSonComponentConfig FooterConfig { get; set; } = VSonComponentConfig.Empty;

        /// <summary>
        /// 在模态开始显示时调用。
        /// Is called when a modal starts to show.
        /// </summary>
        [Parameter]
        public EventCallback OnShow { get; set; }

        /// <summary>
        /// 在模态完成隐藏动画后调用。
        /// Is called after a modal has finished hiding animation.
        /// </summary>
        [Parameter]
        public EventCallback OnHidden { get; set; }
    }
}
