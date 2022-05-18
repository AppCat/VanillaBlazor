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
    /// 响应式分隔符在内容部分之间插入分隔线。
    /// A responsive divider inserts divider lines between sections of content.
    /// </summary>
    public partial class VDivider : VContentComponentBase
    {
        /// <summary>
        /// 组合上下文
        /// </summary>
        protected CombineContext<VDivider, VDividerBlock> Context { get; set; }

        /// <summary>
        /// 设置
        /// </summary>
        protected override void OnSet()
        {
            var fixedClass = "row p-divider";
            ClassMapper.Clear()
            .Add(fixedClass)
            .If("is-dark", () => Dark)
            .If("is-disabled", () => Disabled)
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

            __builder.AddCascadingValue(ref sequence, Context, __builder =>
            {
                var sequence = 0;

                __builder.AddCascadingValue(ref sequence, true, __builder =>
                {
                    var sequence = 0;
                    __builder.AddContent(sequence++, ChildContent);
                }, "DividerInitialize");

                __builder.AddContent(sequence++, ChildContent);
            });

            __builder.CloseComponent();
        };

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Context = new CombineContext<VDivider, VDividerBlock>(this);
        }

        #endregion
    }
}
