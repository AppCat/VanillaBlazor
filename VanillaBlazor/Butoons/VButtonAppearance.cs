using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 按钮
    /// </summary>
    public enum VButtonAppearance
    {
        /// <summary>
        /// 一个基本按钮可以用来指示一个次要的动作。 它经常与默认按钮一起使用。  
        /// A base button can be used to discretely indicate a secondary action. It is often used alongside a default button.
        /// </summary>
        Base,
        /// <summary>
        /// 一个积极的按钮可以用来指示一个积极的行动，这是主要的行动号召。  
        /// A positive button can be used to indicate a positive action that is the main call-to-action.
        /// </summary>
        Positive,
        /// <summary>
        /// 否定按钮可以用来指示具有破坏性或永久性的否定操作。
        /// A negative button can be used to indicate a negative action that is destructive or permanent.
        /// </summary>
        Negative,
        /// <summary>
        /// You can use the brand button with the main color of your brand.
        /// 您可以使用品牌按钮与您的品牌的主颜色。  
        /// </summary>
        Brand,
        /// <summary>
        /// 在某些情况下，您可能需要一个在视觉上与链接相同的按钮。  
        /// In some contexts you may need a button to look visually identical to a link.
        /// </summary>
        Link,
    }
}
