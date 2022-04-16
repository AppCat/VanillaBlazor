using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 类型输入框
    /// </summary>
    public partial class VTypeInput
    {
        #region Parameter        

        /// <summary>
        /// 内容类型
        /// </summary>
        [Parameter]
        public Type ValueType { get; set; }

        #endregion
    }
}
