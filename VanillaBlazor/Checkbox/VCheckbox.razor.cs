using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanillaBlazor.Extensions;

namespace VanillaBlazor
{
    /// <summary>
    /// 这是一个用于Vanilla Checkbox的Blazor组件。  
    /// This is a Blazor component for the Vanilla Checkbox.
    /// </summary>
    public partial class VCheckbox : VInuptComponentBase<bool>
    {
        /// <summary>
        /// 设置
        /// </summary>
        protected override void OnSet()
        {
            var fixedClass = "p-checkbox__input";
            ClassMapper.Clear()
            .Add(fixedClass)
            ;

            LabelConfig = LabelConfig.Copy();
            LabelConfig.AddClass("p-checkbox__label");
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        protected virtual RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;
            __builder.OpenElement(sequence++, "label");
            __builder.AddAttribute(sequence++, "class", "p-checkbox");

            __builder.OpenElement(sequence++, "input");
            __builder.AddComponent(ref sequence, this);

            __builder.IfAddAttribute(ref sequence, "readonly", true, () => ReadOnly);

            __builder.AddAttribute(sequence++, "value", Checked);
            __builder.AddAttribute(sequence++, "type", "checkbox");

            __builder.AddEvent(ref sequence, "onchange", HandleOnChangeAsync);
            //__builder.AddEvent(ref sequence, "onkeyup", HandleOnKeyupAsync);
            //__builder.AddEvent(ref sequence, "oninput", HandleOnInputAsync);
            //__builder.AddEvent(ref sequence, "onfocusin", OnFocusin);

            //__builder.AddElementReferenceCapture(sequence++, element => InputElement = element);

            __builder.CloseElement();
            __builder.OpenElement(sequence++, "span");
            __builder.AddConfig(ref sequence, LabelConfig);
            __builder.AddContent(sequence++, Label);
            __builder.CloseElement();

            __builder.CloseComponent();
        };

        /// <summary>
        /// 处理 OnChange
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected async Task HandleOnChangeAsync(ChangeEventArgs args)
        {

            if(args.Value is bool @checked)
            {
                if (@checked == Checked)
                    return;
                Checked = @checked;
                Value = @checked;
                if (CheckedChanged.HasDelegate)
                {
                    await CheckedChanged.InvokeAsync(Value);
                }
                if (OnCheckedChange.HasDelegate)
                {
                    await OnCheckedChange.InvokeAsync(Value);
                }
            }
        }

    }
}
