using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 分页组件的参数部分
    /// Pagination parameter partial
    /// </summary>
    public partial class VPagination
    {
        /// <summary>
        /// 连接元素。
        /// </summary>
        [Parameter]
        public EnumMix<VOptionalElement>? LinkElement { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        [Parameter]
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 页总数
        /// </summary>
        [Parameter]
        public int PageTotal { get; set; } = 1;

        /// <summary>
        /// 两边显示数量
        /// </summary>
        [Parameter]
        public int BothShow { get; set; } = 2;

        /// <summary>
        /// 能跳
        /// </summary>
        [Parameter]
        public bool CanJump { get; set; }

        /// <summary>
        /// 能下一页
        /// </summary>
        [Parameter]
        public bool CanNext { get; set; } = true;

        /// <summary>
        /// 项目配置
        /// </summary>
        [Parameter]
        public VSonComponentConfig ItemConfig { get; set; } = VSonComponentConfig.Empty;

        /// <summary>
        /// 上一页配置
        /// </summary>
        [Parameter]
        public VSonComponentConfig PreviousConfig { get; set; } = VSonComponentConfig.Empty;

        /// <summary>
        /// 项目配置
        /// </summary>
        [Parameter]
        public VSonComponentConfig LinkConfig { get; set; } = VSonComponentConfig.Empty;

        /// <summary>
        /// 下一页配置
        /// </summary>
        [Parameter]
        public VSonComponentConfig NextConfig { get; set; } = VSonComponentConfig.Empty;

        /// <summary>
        /// 页码变化
        /// </summary>
        [Parameter]
        public EventCallback<int> PageIndexChanged { get; set; }

        /// <summary>
        /// 页码变化事件
        /// </summary>
        [Parameter]
        public EventCallback<VPaginationEventArgs> OnPageIndexChange { get; set; }
    }
}
