using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 模态 配置
    /// </summary>
    public interface IVModalConfig
    {
        /// <summary>
        /// Id
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// 传递的模型
        /// Model of transfer
        /// </summary>
        object Model { get; set; }

        /// <summary>
        /// 样式
        /// </summary>
        string Style { get; set; }

        /// <summary>
        /// 类
        /// </summary>
        string Class { get; set; }

        /// <summary>
        /// 模态的 Header 配置
        /// The header is config for the modal.
        /// </summary>
        VSonComponentConfig HeaderConfig { get; set; }

        /// <summary>
        /// 模态的标题。
        /// The title for the modal.
        /// </summary>
        string? Title { get; set; }

        /// <summary>
        /// 模态的标题模板。
        /// The title is template for the modal.
        /// </summary>
        RenderFragment<object>? TitleTemplate { get; set; }

        /// <summary>
        /// 模态的 Title 配置
        /// The title is config for the modal.
        /// </summary>
        VSonComponentConfig TitleConfig { get; set; }

        /// <summary>
        /// 模态的内容。
        /// The content for the modal.
        /// </summary>
        string? Content { get; set; }

        /// <summary>
        /// 模态的内容模板。
        /// The content is template for the modal.
        /// </summary>
        RenderFragment<object>? ContentTemplate { get; set; }

        /// <summary>
        /// 模态的 Content 配置
        /// The content is config for the modal.
        /// </summary>
        VSonComponentConfig ContentConfig { get; set; }

        /// <summary>
        /// 行为
        /// </summary>
        VModalActionModalConfig[] Actions { get; set; }

        /// <summary>
        /// 模态的内容模板。
        /// The content is template for the modal.
        /// </summary>
        RenderFragment<object>? FooterTemplate { get; set; }

        /// <summary>
        /// 模态的 Footer 配置
        /// The footer is config for the modal.
        /// </summary>
        VSonComponentConfig FooterConfig { get; set; }
    }
}
