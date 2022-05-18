using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 模态配置
    /// </summary>
    public class VModalConfig : IVModalConfig
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 传递的模型
        /// Model of transfer
        /// </summary>
        public object Model { get; set; }

        /// <summary>
        /// 样式
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// 类
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// 模态的 Header 配置
        /// The header is config for the modal.
        /// </summary>
        public VSonComponentConfig HeaderConfig { get; set; } = VSonComponentConfig.Empty;

        /// <summary>
        /// 模态的标题。
        /// The title for the modal.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// 模态的标题模板。
        /// The title is template for the modal.
        /// </summary>
        public RenderFragment<object>? TitleTemplate { get; set; }

        /// <summary>
        /// 模态的 Title 配置
        /// The title is config for the modal.
        /// </summary>
        public VSonComponentConfig TitleConfig { get; set; } = VSonComponentConfig.Empty;

        /// <summary>
        /// 模态的内容。
        /// The content for the modal.
        /// </summary>
        public string? Content { get; set; }

        /// <summary>
        /// 模态的内容模板。
        /// The content is template for the modal.
        /// </summary>
        public RenderFragment<object>? ContentTemplate { get; set; }

        /// <summary>
        /// 模态的 Content 配置
        /// The content is config for the modal.
        /// </summary>
        public VSonComponentConfig ContentConfig { get; set; } = VSonComponentConfig.Empty;

        /// <summary>
        /// 行为
        /// </summary>
        public VModalActionModalConfig[] Actions { get; set; } = new VModalActionModalConfig[0];

        /// <summary>
        /// 模态的内容模板。
        /// The content is template for the modal.
        /// </summary>
        public RenderFragment<object>? FooterTemplate { get; set; }

        /// <summary>
        /// 模态的 Footer 配置
        /// The footer is config for the modal.
        /// </summary>
        public VSonComponentConfig FooterConfig { get; set; } = VSonComponentConfig.Empty;
    }
}
