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
        protected VColumnContext<IVColumn> ColumnContext { get; set; } = new VColumnContext<IVColumn>();

        /// <summary>
        /// 模型
        /// </summary>
        protected static readonly TModel Model = (TModel)RuntimeHelpers.GetUninitializedObject(typeof(TModel));

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        protected override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.OpenComponent<CascadingValue<VColumnContext<IVColumn>>>(sequence++);
            __builder.AddAttribute(sequence++, nameof(CascadingValue<VColumnContext<IVColumn>>.IsFixed), true);
            __builder.AddAttribute(sequence++, nameof(CascadingValue<VColumnContext<IVColumn>>.Value), ColumnContext);

            __builder.AddAttribute(sequence++, nameof(CascadingValue<VColumnContext<IVColumn>>.ChildContent), (RenderFragment)(__builder =>
            {
                __builder.AddContent(sequence++, InitializeFragment());

                __builder.OpenElement(sequence++, "table");

                __builder.AddContent(sequence++, THeaderFragment());

                __builder.AddContent(sequence++, TBodyFragment());

                __builder.CloseElement();
            }));

            __builder.CloseComponent();
        };

        /// <summary>
        /// 初始化渲染
        /// </summary>
        /// <returns></returns>
        private RenderFragment InitializeFragment() => __builder =>
        {
            var sequence = 0;

            if (ChildContent == null)
            {
                return;
            }

            __builder.OpenComponent<CascadingValue<bool>>(sequence++);
            __builder.AddAttribute(sequence++, nameof(CascadingValue<bool>.IsFixed), true);
            __builder.AddAttribute(sequence++, nameof(CascadingValue<bool>.Value), true);
            __builder.AddAttribute(sequence++, nameof(CascadingValue<bool>.Name), "TableInitialize");

            __builder.AddAttribute(sequence++, nameof(CascadingValue<bool>.ChildContent), (RenderFragment)(__builder =>
            {
                var sequence = 0;
                __builder.AddContent(sequence++, ChildContent, Model);
            }));

            __builder.CloseComponent();
        };

        /// <summary>
        /// 头渲染
        /// </summary>
        /// <returns></returns>
        private RenderFragment THeaderFragment() => __builder =>
        {
            var sequence = 0;

            if (ChildContent == null || HideHeader)
            {
                return;
            }

            __builder.OpenComponent<CascadingValue<VColumUse>>(sequence++);
            __builder.AddAttribute(sequence++, nameof(CascadingValue<VColumUse>.IsFixed), true);
            __builder.AddAttribute(sequence++, nameof(CascadingValue<VColumUse>.Value), VColumUse.Header);
            __builder.AddAttribute(sequence++, nameof(CascadingValue<VColumUse>.ChildContent), (RenderFragment)(__builder =>
            {
                var sequence = 0;

                __builder.OpenElement(sequence++, "thead");

                __builder.OpenElement(sequence++, "tr");
                __builder.AddContent(sequence++, ChildContent, Model);
                __builder.CloseElement();

                __builder.CloseComponent();
            }));

            __builder.CloseComponent();
        };

        /// <summary>
        /// 身体渲染
        /// </summary>
        /// <returns></returns>
        private RenderFragment TBodyFragment() => __builder =>
        {
            var sequence = 0;

            if ((DataSource == null || !(DataSource?.Any() ?? false)) && CaptionTemplate != null)
            {
                __builder.AddContent(sequence++, CaptionTemplate);
            }
            else
            {
                __builder.OpenComponent<CascadingValue<VColumUse>>(sequence++);
                __builder.AddAttribute(sequence++, nameof(CascadingValue<VColumUse>.IsFixed), true);
                __builder.AddAttribute(sequence++, nameof(CascadingValue<VColumUse>.Value), VColumUse.Body);
                __builder.AddAttribute(sequence++, nameof(CascadingValue<VColumUse>.ChildContent), (RenderFragment)(__builder =>
                {
                    var sequence = 0;
                    __builder.OpenElement(sequence++, "tbody");

                    if (ChildContent != null && DataSource != null && DataSource.Any())
                    {
                        foreach (var data in DataSource)
                        {
                            __builder.OpenElement(sequence++, "tr");
                            __builder.AddContent(sequence++, ChildContent, data);
                            __builder.CloseElement();
                        }
                    }

                    __builder.CloseComponent();
                }));

                __builder.CloseComponent();
            }
        };

        /// <summary>
        /// 脚渲染
        /// </summary>
        /// <returns></returns>
        private RenderFragment TFootFragment() => __builder =>
        {
            var sequence = 0;

        };

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();

        }

        #endregion
    }
}
