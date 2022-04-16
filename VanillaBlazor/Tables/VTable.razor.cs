using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VanillaBlazor.Extensions;

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

        //private RenderFragment Content() => __builder =>
        //{
        //    var sequence = 0;
        //    __builder.OpenElement(sequence++, "table");
        //    __builder.AddComponent(ref sequence, this);

        //    __builder.IfAddContent(ref sequence, THeaderFragment(), () => ChildContent != null && !HideHeader);
        //    __builder.AddContent(sequence++, TBodyFragment());
        //    __builder.AddContent(sequence++, TFootFragment());

        //    __builder.CloseComponent();
        //};

        private RenderFragment THeaderFragment() => __builder =>
        {
            var sequence = 0;
            __builder.OpenElement(sequence++, "thead");

            if (ChildContent != null)
            {
                __builder.OpenElement(sequence++, "tr");
                __builder.IfAddContent<TModel>(ref sequence, ChildContent, Model, () => ChildContent != null);
                __builder.CloseElement();
            }

            __builder.CloseComponent();
        };

        private RenderFragment TBodyFragment() => __builder =>
        {
            var sequence = 0;
            __builder.OpenElement(sequence++, "tbody");

            if (ChildContent != null && DataSource != null && DataSource.Any())
            {
                foreach (var data in DataSource)
                {
                    __builder.OpenElement(sequence++, "tr");
                    __builder.IfAddContent<TModel>(ref sequence, ChildContent, data, () => ChildContent != null);
                    __builder.CloseElement();
                }
            }

            __builder.CloseComponent();
        };

        private RenderFragment TFootFragment() => __builder =>
        {
            var sequence = 0;

        };

        #endregion
    }
}
