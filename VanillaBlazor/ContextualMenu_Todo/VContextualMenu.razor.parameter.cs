using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 上下文菜单的参数部分
    /// VContextualMenu parameter partial
    /// </summary>
    public partial class VContextualMenu
    {
        /// <summary>
        /// 菜单的位置。
        /// The position of the menu.
        /// </summary>
        [Parameter]
        public EnumMix<VContextualMenuPosition>? Position { get; set; } = VContextualMenuPosition.Right;

        /// <summary>
        /// 菜单是否需要调整以适应屏幕。
        /// Whether the menu should adjust to fit in the screen.
        /// </summary>
        [Parameter]
        public bool AutoAdjust { get; set; } = true;

        /// <summary>
        /// 按下退出键时菜单是否应关闭。
        /// Whether the menu should close when the escape key is pressed.
        /// </summary>
        [Parameter]
        public bool CloseOnEsc { get; set; } = true;

        /// <summary>
        /// 在菜单外点击是否关闭菜单。
        /// Whether the menu should close when clicking outside the menu.
        /// </summary>
        [Parameter]
        public bool CloseOnOutsideClick { get; set; } = true;
        
    }
}
