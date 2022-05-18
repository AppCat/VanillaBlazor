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
    /// 条带模式提供了一个用于包装行的全宽度条带容器。
    /// The strip pattern provides a full width strip container in which to wrap a row.
    /// </summary>
    public partial class VStrip : VContentComponentBase
    {
        /// <summary>
        /// 设置
        /// </summary>
        protected override void OnSet()
        {
            var fixedClass = "p-strip";
            ClassMapper.Clear()
            .Get(() => $"{fixedClass}--{Type}")
            .If("is-bordered", () => Bordered)
            .If("is-dark", () => Dark)
            .If("is-deep", () => Deep)
            .If("is-light", () => Light)
            .If("is-shallow", () => Shallow)
            ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        protected override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.OpenElement(sequence++, "section");
            __builder.AddComponent(ref sequence, this);



            __builder.CloseComponent();
        };
    }
}
