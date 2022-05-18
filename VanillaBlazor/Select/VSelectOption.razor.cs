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
    /// 选择选项
    /// </summary>
    public partial class VSelectOption : VDropdownOptionComponentBase
    {
        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        protected override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.OpenElement(sequence++, "option");
            __builder.AddComponent(ref sequence, this);
            __builder.AddAttribute(sequence++, "value", Key);

            if (Selected)
            {
                __builder.AddAttribute(sequence++, "selected");
            }

            if (Disabled)
            {
                __builder.AddAttribute(sequence++, "disabled");
            }

            __builder.AddEvent(ref sequence, "onclick", HandleOnClickAsync);
            __builder.AddEvent(ref sequence, "onmouseover", HandleOnMouseoverAsync);

            if (ValueTemplate != null)
            {
                __builder.AddContent(sequence++, ValueTemplate, this);
            }
            else if (!string.IsNullOrWhiteSpace(Value))
            {
                __builder.AddContent(sequence++, Value);
            }
            else if (ChildContent != null)
            {
                __builder.AddContent(sequence++, ChildContent);
            }

            __builder.CloseComponent();
        };
    }
}
