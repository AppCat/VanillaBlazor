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
    /// 操作列
    /// Columns of a table used for action
    /// </summary>
    public partial class VActionColumn : VColumnBase
    {
        #region RenderFragment

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        protected override RenderFragment ContentFragment() => __builder =>
        {

            var sequence = 0;
            if (IsInitialize)
            {
                return;
            }
            else if (Use == VColumUse.Header)
            {
                __builder.OpenElement(sequence++, "th");
                __builder.AddConfig(ref sequence, TitleConfig);
                __builder.EitherOrAddContent(ref sequence, TitleTemplate, (Title ?? string.Empty), () => TitleTemplate != null);
            }
            else if (Use == VColumUse.Body)
            {
                __builder.OpenElement(sequence++, "td");
                __builder.AddComponent(ref sequence, this);
                __builder.AddContent(sequence++, ChildContent);
            }

            __builder.CloseComponent();
        };

        #endregion
    }
}
