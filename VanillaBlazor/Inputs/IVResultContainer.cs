using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 结果容器
    /// </summary>
    public interface IVResultContainer
    {
        /// <summary>
        /// 添加结果
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        bool AddResult(IVResult result);

        /// <summary>
        /// 选中的结果
        /// </summary>
        /// <param name="result"></param>
        /// <param name="isClick"></param>
        Task SelectedResultAsync(IVResult result, bool isClick = false);

        /// <summary>
        /// 结果是否选中
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        bool ResultIsSelected(IVResult result);
    }
}
