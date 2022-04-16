using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanillaBlazor;

namespace VanillaBlazor
{
    /// <summary>
    /// 选项
    /// </summary>
    public interface IOption<TKey> : IExternalNotifyStateHasChanged
    {
        /// <summary>
        /// 项Id
        /// </summary>
        string OptionId { get; set; }

        /// <summary>
        /// 键
        /// </summary>
        TKey Key { get; set; }

        /// <summary>
        /// 附加
        /// </summary>
        object Tag { get; set; }

        /// <summary>
        /// 禁用
        /// </summary>
        bool Disabled { get; }
    }
}
