using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 可折叠选项
    /// </summary>
    public interface IDropdownOption<TKey> : IOption<TKey>
    {
        /// <summary>
        /// 值
        /// </summary>
        string Value { get; set; }

        /// <summary>
        /// 值模板
        /// </summary>
        RenderFragment<IDropdownOption<TKey>> ValueTemplate { get; set; }
    }
}
