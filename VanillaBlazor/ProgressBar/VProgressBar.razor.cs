using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanillaBlazor.Extensions;

namespace VanillaBlazor
{
    /// <summary>
    /// 这是一个用于Vanilla ProgressBar的Blazor组件。
    /// This is a Blazor component for the Vanilla ProgressBar.
    /// </summary>
    public partial class VProgressBar : VContentComponentBase
    {
        /// <summary>
        /// 设置
        /// </summary>
        protected override void OnSet()
        {
            var fixedClass = "vb-progress";
            ClassMapper.Clear()
            .Add(fixedClass)
            ;
        }

        /// <summary>
        /// 参数设置
        /// </summary>
        protected override void OnParametersSet()
        {
            BarConfig = BarConfig.Copy();
            BarConfig
            .AddClass("vb-bar")
            .AddIfClass($"{Appearance?.ToClass()}", () => Appearance != null)
            ;

            var percent = (double)(Value ?? 0) / (double)(MaxValue ?? 0);
            if (Value > MaxValue)
                percent = 1;

            if (Appearance == null && Value != null && MaxValue != null && Value >= MaxValue)
            {
                BarConfig.AddClass($"{VProgressBarAppearance.Positive.ToClass()}");
            }

            BarConfig
            .AddStyle("transition-duration", "300ms;")
            .AddStyle("display", "block;")
            .AddStyle("width", $"{percent * 100}%;")
            ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        protected virtual RenderFragment ContentFragment() => __builder =>
        {
            var cssScope = "vb-progressbar";

            var sequence = 0;
            __builder.OpenElement(sequence++, "div");
            __builder.AddAttribute(sequence++, cssScope);
            __builder.AddComponent(ref sequence, this);
            __builder.IfAddAttribute(ref sequence, "value", Value, () => Value != null);
            __builder.IfAddAttribute(ref sequence, "max", MaxValue, () => MaxValue != null);

            RenderFragment bar = __builder =>
            {
                var sequence = 0;
                __builder.OpenElement(sequence++, "div");
                __builder.AddAttribute(sequence++, cssScope);
                __builder.AddConfig(ref sequence, BarConfig);
                __builder.CloseComponent();
            };

            __builder.AddContent(sequence++, bar);

            __builder.CloseComponent();
        };
    }
}
