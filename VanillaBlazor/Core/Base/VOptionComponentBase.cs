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
    /// 选项基础
    /// </summary>
    public abstract class VOptionComponentBase<TSelect, TOption, TKey> : VContentComponentBase, IOption<TKey>
        where TSelect : class, ISelect<TOption, TKey>
        where TOption : class, IOption<TKey>
        where TKey : notnull
    {
        /// <summary>
        /// 活跃
        /// </summary>
        protected bool Selected => ParentSelect?.OptionIsSelected(this as TOption) ?? false;

        /// <summary>
        /// 过滤
        /// </summary>
        protected bool Filtered => ParentSelect?.OptionIsFiltered(this as TOption) ?? false;

        /// <summary>
        /// 选择
        /// </summary>
        protected bool Focus => ParentSelect?.OptionIsFocus(this as TOption) ?? false;

        #region CascadingParameter

        /// <summary>
        /// 母体
        /// </summary>
        [CascadingParameter(Name = "ParentSelect")]
        protected TSelect? ParentSelect { get; set; }

        #endregion

        /// <summary>
        /// 项Id
        /// </summary>
        public virtual string OptionId { get; set; }

        #region Parameter        

        /// <summary>
        /// 键
        /// </summary>
        [Parameter]
        public virtual TKey Key { get; set; }

        /// <summary>
        /// 附加
        /// </summary>
        [Parameter]
        public virtual object? Tag { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 点击事件
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        #endregion

        /// <summary>
        /// 处理点击
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected async Task HandleOnClickAsync(MouseEventArgs args)
        {
            if (Disabled)
                return;

            await OnClick.InvokeAsync(args);
            if (ParentSelect != null)
            {
                await ParentSelect.SelectedOptionAsync(this as TOption, true);
            }
        }

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            OptionId ??= Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 设置属性后
        /// </summary>
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            ParentSelect?.AddOption(this as TOption);
        }

        #endregion

        /// <summary>
        /// 通知状态变化
        /// </summary>
        public void NotifyStateHasChanged() => InvokeStateHasChanged();
    }
}
