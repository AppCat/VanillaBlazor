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
    /// 可折叠选项组件基础
    /// </summary>
    public abstract class VDropdownOptionComponentBase : VOptionComponentBase<IDropdown<string>, IDropdownOption<string>, string>, IDropdownOption<string>
    {
        #region Event

        /// <summary>
        /// 鼠标移到项目之上
        /// </summary>
        /// <returns></returns>
        protected async Task HandleOnMouseoverAsync()
        {
            if(ParentSelect != null)
            {
                await ParentSelect.FocusOptionAsync(this);
            }
        }

        #endregion

        #region SDLC

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Value ??= Key;
        }

        #endregion

        /// <summary>
        /// 内容
        /// </summary>
        [Parameter]
        public string? Value { get; set; }

        /// <summary>
        /// 内容模板
        /// </summary>
        [Parameter]
        public RenderFragment<IDropdownOption<string>>? ValueTemplate { get; set; }
    }
}
