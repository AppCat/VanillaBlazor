using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanillaBlazor.Extensions;

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
        /// 宽度
        /// </summary>
        protected decimal? Width { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        protected decimal? Height { get; set; }

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
            .If("is-fluid", () => Fluid)
            ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        protected override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;
            var cssScope = "vb-button";

            if (Element != null)
            {
                __builder.OpenElement(sequence++, Element.ToClass());
            }
            else
            {
                __builder.OpenElement(sequence++, "button");
            }

            __builder.AddAttribute(sequence++, cssScope);
            __builder.AddComponent(ref sequence, this); 
            __builder.IfAddAttribute(ref sequence, "type", InputType, () => !string.IsNullOrWhiteSpace(InputType));
            __builder.AddEvent(ref sequence, "onclick", HandleOnClickAsync, OnClickStopPropagation);

            if (Processing)
            {
                if (Height != null && Width != null)
                {
                    var top = ((Height ?? 0) - (decimal)24.2) / 2;
                    top = top <= 0 ? 0 : top;
                    __builder.AddContent(sequence++, new MarkupString($"<div style='width: {Width}px; height: {Height}px;'><i style='top: {top}px;' class='p-icon--spinner u-animation--spin'></i></div>"));
                }
                else
                {
                    __builder.AddContent(sequence++, new MarkupString("<i class='p-icon--spinner u-animation--spin'></i>"));
                }
            }
            else
            {
                __builder.EitherOrAddContent(ref sequence, ChildContent, Content, () => ChildContent != null);
            }

            __builder.CloseComponent();
        };

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
        protected virtual async Task Click(MouseEventArgs args)
        {
            if (Processing || Disabled)
                return;
            Processing = true;
            await ProcessingChanged.InvokeAsync(Processing);
            await OnClick.InvokeAsync(args);
            Processing = false;
            await ProcessingChanged.InvokeAsync(Processing);
        }

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            //await WindowHelp.AddEventListenerAsync(this, "resize");
            await base.OnInitializedAsync();
        }

        /// <summary>
        /// 释放
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            //WindowHelp.RemoveEventListenerAsync(this, "resize");
            base.Dispose(disposing);
        }

        /// <summary>
        /// 渲染后
        /// </summary>
        /// <param name="firstRender"></param>
        /// <returns></returns>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!Processing)
            {
                var clientWidth = await ElementHelp.GetElementPropertyByIdAsync<decimal>(Id, "clientWidth");
                var clientHeight = await ElementHelp.GetElementPropertyByIdAsync<decimal>(Id, "clientHeight");

                var padding = await ElementHelp.GetComputedStylesByIdAsync(Id, "paddingTop", "paddingBottom", "paddingLeft", "paddingRight");

                if (padding == null)
                {
                    Height = clientHeight;
                    Width = clientWidth;
                }
                else
                {
                    var pt = ConvertPx(padding?[0]);
                    var pb = ConvertPx(padding?[1]);
                    var pl = ConvertPx(padding?[2]);
                    var pr = ConvertPx(padding?[3]);
                    if (pt != null && pb != null)
                    {
                        Height = clientHeight - pt - pb - 0.190m;
                    }

                    if (pl != null && pr != null)
                    {
                        Width = clientWidth - pl - pr - 0.190m;
                    }
                }
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        #endregion
    }
}
