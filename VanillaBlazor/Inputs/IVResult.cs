using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 结果
    /// </summary>
    public interface IVResult
    {
        /// <summary>
        /// 键 (唯一必填)
        /// </summary>
        string Key { get; }

        /// <summary>
        /// 标题
        /// </summary>
        string Title { get; }

        /// <summary>
        /// 标题模板
        /// </summary>
        RenderFragment TitleTemplate { get; }

        /// <summary>
        /// 描述
        /// </summary>
        string Description { get; }

        /// <summary>
        /// 价值
        /// </summary>
        string Price { get; }

        /// <summary>
        /// 地址
        /// </summary>
        string Url { get; set; }

        /// <summary>
        /// 附加
        /// </summary>
        object Tag { get; set; }
    }
}
