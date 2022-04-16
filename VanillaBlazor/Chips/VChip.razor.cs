using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 使用炸薯条组件来显示小的可操作的信息片段。
    /// Use the chip component to display small actionable pieces of information.
    /// </summary>
    public partial class VChip : VComponentBase
    {
        /// <summary>
        /// 设置
        /// </summary>
        protected override void OnSet()
        {
            var fixedClass = "p-chip";
            ClassMapper.Clear()
            .If(fixedClass, () => Appearance == null)
            .If($"{fixedClass}--{Appearance?.ToClass()}", () => Appearance != null)
            .If("is-dense", () => Dense)
            .If("is-inline", () => Inline)
            .If("is-small", () => Small)
            .If("is-dark", () => Dark)
            ;
        }

        /// <summary>
        /// 设置参数
        /// </summary>
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            LeadConfig = new VSonComponentConfig(LeadConfig);
            LeadConfig.AddClass("p-chip__lead");

            ValueConfig = new VSonComponentConfig(ValueConfig);
            ValueConfig.AddClass("p-chip__value");
        }
    }
}
