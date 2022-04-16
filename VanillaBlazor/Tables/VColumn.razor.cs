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
    /// 数据表列
    /// Columns of a table
    /// </summary>
    public partial class VColumn<TField> : VColumnBase
    {
        /// <summary>
        /// 属性反射器
        /// </summary>
        private PropertyReflector? _propertyReflector { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName => _propertyReflector?.DisplayName;

        /// <summary>
        /// 属性名称
        /// </summary>
        public string FieldName => _propertyReflector?.PropertyName; 

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            //FieldExpression = () => Field;
            if (FieldExpression != null && Use == VColumUse.Header)
            {
                _propertyReflector = PropertyReflector.Create(FieldExpression);
            }
            if (IsInitialize)
            {
                ColumnContext?.AddColumn(this);
            }
        }

        #endregion

        #region RenderFragment

        private RenderFragment Content() => __builder =>
        {
            if (IsInitialize)
            {
                return;
            }
            var sequence = 0;

            if (Use == VColumUse.Header)
            {
                __builder.OpenElement(sequence++, "th");
                __builder.AddConfig(ref sequence, TitleConfig);
                __builder.EitherOrAddContent(ref sequence, TitleTemplate, (Title ?? DisplayName ?? FieldName ?? string.Empty), () => TitleTemplate != null);
            }
            else if (Use == VColumUse.Body)
            {
                __builder.OpenElement(sequence++, "td");
                __builder.AddComponent(ref sequence, this);
                __builder.EitherOrAddContent(ref sequence, ChildContent, (string.IsNullOrEmpty(Format) ? (Field?.ToString() ?? string.Empty) : Formatter<TField>.Format(Field, Format)), () => ChildContent != null);
            }

            __builder.CloseComponent();
        };

        #endregion
    }
}
