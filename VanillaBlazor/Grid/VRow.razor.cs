using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 行
    /// This is a Blazor component for use within the Vanilla Grid.
    /// Vanilla has a responsive grid using a combination of rows and columns.
    /// </summary>
    public partial class VRow : VContentComponentBase
    {
        /// <summary>
        /// 设置
        /// </summary>
        protected override void OnSet()
        {
            var fixedClass = "row";
            ClassMapper.Clear()
            .Add(fixedClass)
            ;
        }
    }
}
