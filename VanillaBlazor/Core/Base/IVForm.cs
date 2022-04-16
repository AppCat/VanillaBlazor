using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 表单
    /// </summary>
    public interface IVForm
    {
        /// <summary>
        /// 添加表单项
        /// </summary>
        /// <param name="field"></param>
        internal void AddFormItem(IVField field);

        /// <summary>
        /// 添加控制组件
        /// </summary>
        /// <param name="valueAccessor"></param>
        internal void AddControl(IControlValueAccessor valueAccessor);

        /// <summary>
        /// 编辑上下文 
        /// </summary>
        EditContext EditContext { get; }

        /// <summary>
        /// 模型
        /// </summary>
        internal object Model { get; }

        /// <summary>
        /// 重置
        /// </summary>
        void Reset();

        /// <summary>
        /// 提交
        /// </summary>
        void Submit();

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        bool Validate();
    }
}
