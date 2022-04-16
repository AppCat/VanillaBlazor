using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor.Services
{
    /// <summary>
    /// 模态服务
    /// </summary>
    public class VModalService
    {
        /// <summary>
        /// 显示消息事件
        /// </summary>
        internal Func<IVModalConfig, Task>? OnShowModal { get; set; }

        /// <summary>
        /// 显示模态
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public async Task ShowModalAsync(IVModalConfig config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            if(OnShowModal != null)
            {
                await OnShowModal.Invoke(config);
            }
        }
    }
}
