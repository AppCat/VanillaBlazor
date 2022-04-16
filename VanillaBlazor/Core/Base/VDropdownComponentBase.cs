using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 可折叠组件基础
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class VDropdownComponentBase<TKey> : VSelectComponentBase<IDropdownOption<TKey>, TKey>, IDropdown<TKey>
        where TKey : notnull
    {
        /// <summary>
        /// 可见度
        /// </summary>
        [Parameter]
        public EnumMix<VVisibility>? Visibility { get; set; }

        /// <summary>
        /// 能见度变化
        /// </summary>
        [Parameter]
        public EventCallback<EnumMix<VVisibility>> VisibilityChanged { get; set; }

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public virtual async Task Show()
        {
            if (Visibility?.Value == VVisibility.Visible)
                return;
            Visibility = VVisibility.Visible;
            await VisibilityChanged.InvokeAsync(Visibility);
            SelectClear();
            StateHasChanged();
        }

        /// <summary>
        /// 隐藏
        /// </summary>
        /// <returns></returns>
        public virtual async Task Hide()
        {
            if (Visibility?.Value == VVisibility.Hidden)
                return;
            Visibility = VVisibility.Hidden;
            await VisibilityChanged.InvokeAsync(Visibility);
            StateHasChanged();
        }
    }
}
