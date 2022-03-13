using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 数据表用于组织和显示一个数据集中的所有信息。
    /// Data tables are used to organize and display all information from a data set.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public partial class VTable<TModel> : VContentComponentBase<TModel>
    {
        /// <summary>
        /// 列上下文
        /// </summary>
        protected VColumnContext<IVColumn> ColumnContext { get; set; }

        /// <summary>
        /// 模型
        /// </summary>
        protected static readonly TModel Model = (TModel)RuntimeHelpers.GetUninitializedObject(typeof(TModel));

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            ColumnContext = new VColumnContext<IVColumn>();
        }

        #endregion
    }
}
