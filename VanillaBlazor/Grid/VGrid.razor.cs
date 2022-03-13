using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 香草有一个响应式网格
    /// Vanilla has a responsive grid with the following columns and gutters
    /// </summary>
    public partial class VGrid : VContentComponentBase
    {
        /// <summary>
        /// 设置
        /// </summary>
        protected override void OnSet()
        {
            var fixedClass = "grid";
            ClassMapper.Clear()
            .If(fixedClass, () => !Demo)
            .If($"{fixedClass}-demo", () => Demo)
            .If("row", () => Row)
            ;
        }

        /// <summary>
        /// 通过在列中添加.row类，可以无限嵌套列。
        /// Columns can be nested infinitely by adding .row classes within columns.
        /// </summary>
        [Parameter]
        public bool Row { get; set; }

        /// <summary>
        /// 演示
        /// </summary>
        [Parameter]
        public bool Demo { get; set; }
    }
}
