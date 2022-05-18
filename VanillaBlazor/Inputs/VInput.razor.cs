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
    /// 这是一个用于Vanilla Input的Blazor组件。
    /// This is a Blazor component for the Vanilla Input.
    /// An input field where the user can enter data, which can vary in many ways, depending on the type attribute.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public partial class VInput<TValue> : VInputBase<TValue>
    {
        /// <summary>
        /// 输入框内容
        /// </summary>
        private string _inputValue => string.IsNullOrEmpty(Format) ? Value?.ToString() ?? string.Empty : Formatter<TValue>.Format(Value, Format);

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        protected override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.OpenElement(sequence++, "input");
            __builder.AddComponent(ref sequence, this);

            __builder.IfAddAttribute(ref sequence, "readonly", true, () => ReadOnly);
            __builder.IfAddAttribute(ref sequence, "value", _inputValue, () => !string.IsNullOrWhiteSpace(_inputValue));
            __builder.IfAddAttribute(ref sequence, "placeholder", Placeholder, () => !string.IsNullOrWhiteSpace(Placeholder));

            __builder.AddAttribute(sequence++, "type", InputType.ToClass());

            __builder.AddEvent(ref sequence, "onchange", HandleOnChangeAsync);
            __builder.AddEvent(ref sequence, "onkeyup", HandleOnKeyupAsync);
            __builder.AddEvent(ref sequence, "oninput", HandleOnInputAsync);
            __builder.AddEvent(ref sequence, "onfocusin", OnFocusin);

            //__builder.AddElementReferenceCapture(sequence++, element => InputElement = element);

            if (ChildContent != null && Value != null)
            {
                __builder.AddContent(sequence++, ChildContent, Value);
            }

            __builder.CloseComponent(); 
        };
    }
}
