using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 列
    /// This is a Blazor component for use within the Vanilla Grid.
    /// Vanilla has a responsive grid using a combination of rows and columns.
    /// </summary>
    public partial class VCol : VContentComponentBase
    {
        /// <summary>
        /// 设置
        /// </summary>
        protected override void OnSet()
        {
            var fixedClass = "col";
            ClassMapper.Clear()
            .If(fixedClass, () => Size == null)
            .If($"{fixedClass}-{(int)Size.Value}", () => Size != null)
            .GetIf(() => $"col-start-large-{(int)EmptyLarge.Value}", () => EmptyLarge != null)
            .GetIf(() => $"col-start-medium-{(int)EmptyMedium.Value}", () => EmptyMedium != null)
            .GetIf(() => $"col-start-small-{(int)EmptySmall.Value}", () => EmptySmall != null)
            .GetIf(() => $"col-large-{(int)Large.Value}", () => Large != null)
            .GetIf(() => $"col-medium-{(int)Medium.Value}", () => Medium != null)
            .GetIf(() => $"col-small-{(int)Small.Value}", () => Small != null)
            ;
        }
    }
}
