using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 条带类型
    /// </summary>
    public enum VStripType
    {
        /// <summary>
        /// 光线
        /// </summary>
        Light,
        /// <summary>
        /// 暗
        /// </summary>
        Dark,
        /// <summary>
        /// 重音
        /// </summary>
        Accent,
        /// <summary>
        /// 图像
        /// </summary>
        Image,
        /// <summary>
        /// 带图案
        /// </summary>
        Suru,
        /// <summary>
        /// Suru Topped
        /// </summary>
        [EnumClass("suru-topped")]
        SuruTopped
    }
}
