using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanillaBlazor.Extensions;

namespace VanillaBlazor
{
    /// <summary>
    /// 分页组件应该用于在内容页面之间导航。 根据提供的长度，分页组件将自动伸缩。  
    /// This is a React component for the Vanilla Pagination.
    /// The pagination component should be used to navigate between pages of content.Depending on the length provided, the pagination component will automatically scale.
    /// </summary>
    public partial class VPagination : VComponentBase
    {
        /// <summary>
        /// 设置
        /// </summary>
        protected override void OnSet()
        {
            var fixedClass = "p-pagination";
            ClassMapper.Clear()
            .Add(fixedClass)
            ;
        }

        /// <summary>
        /// 设置参数
        /// </summary>
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            ItemConfig = new VSonComponentConfig(ItemConfig);
            ItemConfig.AddClass("p-pagination__item");

            PreviousConfig = new VSonComponentConfig(PreviousConfig);
            PreviousConfig.AddClass("p-pagination__link--previous");

            LinkConfig = new VSonComponentConfig(LinkConfig);
            LinkConfig.AddClass("p-pagination__link");

            NextConfig = new VSonComponentConfig(NextConfig);
            NextConfig.AddClass("p-pagination__link--next");
        }

        /// <summary>
        /// 内容
        /// </summary>
        /// <returns></returns>
        protected override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;
            __builder.OpenElement(sequence++, "ol");
            __builder.AddComponent(ref sequence, this);

            var linkElement = LinkElement?.Value.ToString().ToLowerInvariant() ?? "button";
            var icon = new MarkupString("<i class='p-icon--chevron-down'></i>");
            var threePoints = new MarkupString("<li class='p-pagination__item p-pagination__item--truncation'>…</li>");

            RenderFragment item(RenderFragment link) => __builder =>
            {
                var sequence = 0;
                __builder.OpenElement(sequence++, "li");
                __builder.AddConfig(ref sequence, ItemConfig);
                __builder.AddContent(sequence++, link);
                __builder.CloseComponent();
            };

            if (CanNext)
            {
                RenderFragment previous = __builder =>
                {
                    var sequence = 0;
                    __builder.OpenElement(sequence++, linkElement);
                    __builder.AddConfig(ref sequence, PreviousConfig);
                    __builder.AddAttribute(sequence++, "onclick", () => HandleOnClickItemAsync(PageIndex - 1));
                    __builder.AddContent(sequence++, icon);
                    __builder.CloseComponent();
                };

                __builder.AddContent(sequence++, item(previous));
            }

            foreach (var link in GenerateLinks())
            {
                if(link.index == null)
                {
                    __builder.AddContent(sequence++, threePoints);
                    continue;
                }

                RenderFragment link_ = __builder =>
                {
                    var sequence = 0;
                    var linkConfig = LinkConfig.Copy();
                    linkConfig.AddIfClass("is-active", () => link.active);
                    __builder.OpenElement(sequence++, linkElement);
                    __builder.AddConfig(ref sequence, linkConfig);
                    Console.WriteLine(linkConfig.AsClass);
                    __builder.AddAttribute(sequence++, "onclick", () => HandleOnClickItemAsync(link.index ?? 1));
                    __builder.AddContent(sequence++, link.index?.ToString());
                    __builder.CloseComponent();
                };

                __builder.AddContent(sequence++, item(link_));
            }

            if (CanNext)
            {
                RenderFragment next = __builder =>
                {
                    var sequence = 0;
                    __builder.OpenElement(sequence++, linkElement);
                    __builder.AddConfig(ref sequence, NextConfig);
                    __builder.AddAttribute(sequence++, "onclick", () => HandleOnClickItemAsync(PageIndex + 1));
                    __builder.AddContent(sequence++, icon);
                    __builder.CloseComponent();
                };

                __builder.AddContent(sequence++, item(next));
            }

            __builder.CloseComponent();
        };

        /// <summary>
        /// 生成页码项
        /// </summary>
        private IEnumerable<(int? index, bool active)> GenerateLinks()
        {
            int show = BothShow * 2 + 1;
            int start;
            int end;
            if (PageTotal < PageIndex)
            {
                PageTotal = PageIndex;
            }
            var items = new List<(int?, bool)>();
            if (PageIndex < BothShow * 2)
            {
                start = 1;
                end = 1 + BothShow * 2;
            }
            else if (PageIndex + BothShow >= PageTotal)
            {
                start = PageTotal - BothShow * 2;
                end = PageTotal;
            }
            else
            {
                start = PageIndex - BothShow;
                end = PageIndex + BothShow; ;
            }
            if (end > PageTotal)
                end = PageTotal;
            if (start <= 0)
                start = 1;
            if (PageIndex > (BothShow + 1) && PageTotal > BothShow * 2 && start != 1)
            {
                items.Add((1, false));
                items.Add((null, false));
            }
            for (int i = start; i <= end; i++)
            {
                var index = i;
                items.Add((index, index == PageIndex));
            }
            if (PageIndex < (PageTotal - BothShow) && PageTotal > BothShow * 2 && end != PageTotal)
            {
                items.Add((null, false));
                items.Add((PageTotal, false));
            }
            if (PageIndex > end)
            {
                HandleOnClickItemAsync(end).Wait();
            }
            return items;
        }

        /// <summary>
        /// 点击页码项
        /// </summary>
        /// <returns></returns>
        private async Task HandleOnClickItemAsync(int index)
        {
            if (Disabled)
                return;
            if (index < 1)
                PageIndex = 1;
            else if (index > PageTotal)
                PageIndex = PageTotal;
            else
                PageIndex = index;
            //PageIndex = index < 1 || index > PageTotal ? PageIndex : index;
            if (PageIndexChanged.HasDelegate)
            {
                await PageIndexChanged.InvokeAsync(PageIndex);
            }
            if (OnPageIndexChange.HasDelegate)
            {
                await OnPageIndexChange.InvokeAsync(new VPaginationEventArgs(PageIndex, PageTotal));
            }
        }
    }
}
