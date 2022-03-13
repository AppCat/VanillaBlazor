using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 数据表列
    /// Columns of a table
    /// </summary>
    /// <typeparam name="TField"></typeparam>
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
    }
}
