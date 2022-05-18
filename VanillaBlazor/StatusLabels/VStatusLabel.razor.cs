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
    /// 状态标签是静态元素，您可以应用它来表示状态、标签或任何其他您认为有用的信息。
    /// Status labels are static elements which you can apply to signify status, tags or any other information you find useful.
    /// </summary>
    public partial class VStatusLabel : VComponentBase
    {
        /// <summary>
        /// 设置
        /// </summary>
        protected override void OnSet()
        {
            var fixedClass = "p-status-label";
            ClassMapper.Clear()
            .If(fixedClass, () => Status == null)
            .If($"{fixedClass}--{Status?.ToClass()}", () => Status != null)
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

            __builder.AddContent(sequence++, Label);

            __builder.CloseComponent();
        };
    }
}
