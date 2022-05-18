using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanillaBlazor.Extensions;

namespace VanillaBlazor
{
    /// <summary>
    /// 字段
    /// </summary>
    public partial class VField
    {
        /// <summary>
        /// 设置
        /// </summary>
        protected override void OnSet()
        {
            var fixedClass = "p-form__group p-form-validation";
            ClassMapper.Clear()
            .Add(fixedClass)
            .If("row", () => Stacked)
            ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        protected override RenderFragment ContentFragment() => __builder => 
        {
            var sequence = 0;

            __builder.OpenElement(sequence++, "div");
            __builder.AddComponent(ref sequence, this);

            if (Stacked)
            {
                __builder.OpenElement(sequence++, "div");
                __builder.AddAttribute(sequence++, "class", "col-4");
            }

            __builder.OpenElement(sequence++, "label");
            __builder.AddConfig(ref sequence, LabelConfig);

            __builder.EitherOrAddContent(ref sequence, LabelTemplate, Label, () => LabelTemplate != null);

            __builder.CloseElement();

            if (Stacked)
            {
                __builder.CloseElement();
            }

            if (Stacked)
            {
                __builder.OpenElement(sequence++, "div");
                __builder.AddAttribute(sequence++, "class", "col-8");
            }

            __builder.OpenElement(sequence++, "div");
            __builder.AddConfig(ref sequence, ControlConfig);

            __builder.IfAddContent(ref sequence, ChildContent, () => ChildContent != null);

            __builder.CloseElement();

            if (Stacked)
            {
                __builder.CloseElement();
            }

            __builder.CloseComponent();
        };

        /// <summary>
        /// 参数设置
        /// </summary>
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            LabelConfig = LabelConfig.Copy();
            LabelConfig.AddClass("p-form__label");
            LabelConfig.AddIfClass("is-required", () => Required);

            ControlConfig = LabelConfig.Copy();
            ControlConfig.AddClass("p-form__control u-clearfix");
        }
    }
}
