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
    /// 这是一个用于Vanilla Select的Blazor组件。  
    /// This is a Blazor component for the Vanilla Select.
    /// </summary>
    public partial class VSelect : VDropdownComponentBase<string>
    {
        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        protected override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.OpenElement(sequence++, "select");
            __builder.AddComponent(ref sequence, this);

            __builder.AddEvent<ChangeEventArgs>(ref sequence, "onchange", this, async args =>
            {
                if(args != null && args.Value != null)
                {
                    var key = args.Value.ToString();
                    if (Options.ContainsKey(key))
                    {
                        await SelectedOptionAsync(Options[key], true);
                    }
                }
            });

            if (!string.IsNullOrWhiteSpace(Placeholder))
            {
                __builder.OpenComponent<VSelectOption>(sequence++);

                __builder.AddAttribute(sequence++, nameof(VSelectOption.Key), nameof(Placeholder));
                __builder.AddAttribute(sequence++, nameof(VSelectOption.Value), Placeholder);
                __builder.AddAttribute(sequence++, nameof(VSelectOption.Disabled), true);
                __builder.AddAttribute(sequence++, nameof(VSelectOption.Attributes), new Dictionary<string, object> { { "selected", true } });

                __builder.CloseComponent();
            }

            if (ChildContent != null)
            {
                __builder.AddContent(sequence++, ChildContent);
            }

            __builder.CloseComponent();
        };
    }
}
