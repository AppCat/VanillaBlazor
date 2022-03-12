using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 按钮是用于执行操作的可点击元素，您可以对按钮和链接元素应用按钮类。
    /// Buttons are clickable elements used to perform an action, you can apply button classes on buttons and link elements.
    /// Note: Do not use multiple button classes on one HTML element.
    /// </summary>
    public partial class VButton : VContentComponentBase
    {
        /// <summary>
        /// 设置
        /// </summary>
        protected override void OnSet()
        {
            var fixedClass = "p-button";
            ClassMapper.Clear()
            .If(fixedClass, () => Appearance == null)
            .If($"{fixedClass}--{Appearance?.ToClass()}", () => Appearance != null)
            .If("is-dense", () => Dense)
            .If("has-icon", () => HasIcon)
            .If("is-inline", () => Inline)
            .If("is-small", () => Small)
            .If("is-processing", () => Processing)
            .If("is-dark", () => Theming)
            ;
        }

        /// <summary>
        /// 处理 OnClick
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual async Task HandleOnClickAsync(MouseEventArgs args)
        {
            await Click(args);
        }

        /// <summary>
        /// 点击
        /// </summary>
        /// <returns></returns>
        protected async Task Click(MouseEventArgs args)
        {
            if (Processing)
                return;
            Processing = true;
            await ProcessingChanged.InvokeAsync(Processing);
            await OnClick.InvokeAsync(args);
            Processing = false;
            await ProcessingChanged.InvokeAsync(Processing);
        }
    }
}
