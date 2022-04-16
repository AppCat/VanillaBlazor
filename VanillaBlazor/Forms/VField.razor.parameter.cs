using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 字段
    /// </summary>
    public partial class VField
    {
        /// <summary>
        /// 必需的
        /// </summary>
        [Parameter]
        public bool Required { get; set; }

        /// <summary>
        /// 字段的标签
        /// The label for the field.
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// 字段的标签模板。
        /// The label is template for the field.
        /// </summary>
        [Parameter]
        public RenderFragment LabelTemplate { get; set; }

        /// <summary>
        /// 字段的标签配置
        /// The label is config for the field.
        /// </summary>
        [Parameter]
        public VSonComponentConfig LabelConfig { get; set; } = VSonComponentConfig.Empty;

        /// <summary>
        /// 字段的控件配置
        /// The control is config for the field.
        /// </summary>
        [Parameter]
        public VSonComponentConfig ControlConfig { get; set; } = VSonComponentConfig.Empty;

        #region CascadingParameter

        /// <summary>
        /// 堆叠
        /// </summary>
        [CascadingParameter]
        protected IVForm? Form { get; set; }

        /// <summary>
        /// 堆叠
        /// </summary>
        [CascadingParameter(Name = "Stacked")]
        protected bool Stacked { get; set; }

        #endregion


    }
}
