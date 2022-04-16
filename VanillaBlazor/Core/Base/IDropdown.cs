using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 可折叠
    /// </summary>
    public interface IDropdown<TKey> : ISelect<IDropdownOption<TKey>, TKey>
    {
        /// <summary>
        /// 可见度
        /// </summary>
        EnumMix<VVisibility> Visibility { get; set; }

        /// <summary>
        /// 能见度变化
        /// </summary>
        EventCallback<EnumMix<VVisibility>> VisibilityChanged { get; set; }       

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        Task Show();

        /// <summary>
        /// 隐藏
        /// </summary>
        /// <returns></returns>
        Task Hide();
    }
}
