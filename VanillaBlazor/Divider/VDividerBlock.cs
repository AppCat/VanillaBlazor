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
    /// 作为分隔符的块
    /// block as divider
    /// </summary>
    public partial class VDividerBlock : VContentComponentBase
    {
        /// <summary>
        /// 设置
        /// </summary>
        protected override void OnSet()
        {
            var fixedClass = "p-divider__block";

            ClassMapper.Clear()
            .Add(fixedClass)
            .GetIf(() => $"col-{12 / (CombineContext.Sons.Count <= 0 ? 1 : CombineContext.Sons.Count)}", () => CombineContext != null)
            ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        protected override RenderFragment ContentFragment() => __builder =>
        {
            if (DividerInitialize)
                return;

            var sequence = 0;

            __builder.OpenElement(sequence++, "div");
            __builder.AddComponent(ref sequence, this);

            __builder.EitherOrAddContent(ref sequence, ChildContent, __builder => 
            {
                __builder.OpenElement(sequence++, "h2");
                __builder.AddConfig(ref sequence, TitleConfig);
                if (TitleTemplate != null)
                {
                    __builder.AddContent(sequence++, TitleTemplate);
                }
                else
                {
                    __builder.AddContent(sequence++, Title);
                }
                __builder.CloseElement();

                __builder.OpenElement(sequence++, "p");
                __builder.AddConfig(ref sequence, ContentConfig);
                if (TitleTemplate != null)
                {
                    __builder.AddContent(sequence++, ContentTemplate);
                }
                else
                {
                    __builder.AddContent(sequence++, Content);
                }
                __builder.CloseElement();

            }, () => ChildContent != null);

            __builder.CloseComponent();
        };

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            if (DividerInitialize)
            {
                CombineContext?.AddSon(this);
            }
            base.OnInitialized();
        }

        #endregion
    }
}
