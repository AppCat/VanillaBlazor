using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanillaBlazor.Services;

namespace VanillaBlazor
{
    /// <summary>
    /// 模态控制
    /// </summary>
    public partial class VModalManager : VComponentBase
    {
        /// <summary>
        /// 模态服务
        /// </summary>
        [Inject]
        protected VModalService? ModalService { get; set; }

        /// <summary>
        /// 显示的模态
        /// </summary>
        protected Dictionary<string, IVModalConfig> ShowModals { get; set; } = new Dictionary<string, IVModalConfig>();

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            if (ModalService != null && ModalService.OnShowModal == null)
            {
                ModalService.OnShowModal = HandleOnShowModal;
            }
        }

        /// <summary>
        /// 内容片段
        /// </summary>
        /// <returns></returns>
        protected override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;
            __builder.OpenElement(sequence++, "div");

            foreach (var item in ShowModals)
            {
                RenderFragment modal(IVModalConfig config) => __builder =>
                {
                    __builder.OpenComponent<VModal>(sequence++);
                    __builder.AddAttribute(sequence++, nameof(VModal.Id), config.Id);
                    __builder.AddAttribute(sequence++, nameof(VModal.Style), config.Style);
                    __builder.AddAttribute(sequence++, nameof(VModal.Class), config.Class);
                    __builder.AddAttribute(sequence++, nameof(VModal.Model), config.Model);
                    __builder.AddAttribute(sequence++, nameof(VModal.Title), config.Title);
                    __builder.AddAttribute(sequence++, nameof(VModal.TitleTemplate), config.TitleTemplate);
                    __builder.AddAttribute(sequence++, nameof(VModal.Content), config.Content);
                    __builder.AddAttribute(sequence++, nameof(VModal.ContentTemplate), config.ContentTemplate);
                    __builder.AddAttribute(sequence++, nameof(VModal.Actions), config.Actions);
                    __builder.AddAttribute(sequence++, nameof(VModal.FooterTemplate), config.FooterTemplate);
                    __builder.AddAttribute(sequence++, nameof(VModal.HeaderConfig), config.HeaderConfig);
                    __builder.AddAttribute(sequence++, nameof(VModal.TitleConfig), config.TitleConfig);
                    __builder.AddAttribute(sequence++, nameof(VModal.ContentConfig), config.ContentConfig);
                    __builder.AddAttribute(sequence++, nameof(VModal.FooterConfig), config.FooterConfig);
                    __builder.AddAttribute(sequence++, nameof(VModal.OnHidden), EventCallback.Factory.Create(this, () => HandleOnHideModal(config.Id)));
                    __builder.AddComponentReferenceCapture(sequence++, @ref =>
                    {
                        (@ref as VModal)?.ShowAsync();
                    });
                    __builder.CloseComponent();
                };
                __builder.AddContent(sequence++, modal(item.Value));
            }

            __builder.CloseComponent();
        };

        /// <summary>
        /// 处理显示 模态
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        protected async Task HandleOnShowModal(IVModalConfig config)
        {
            if (config == null)
                return;
            config.Id ??= Guid.NewGuid().ToString("N");
            ShowModals.TryAdd(config.Id, config);
            await InvokeStateHasChangedAsync();
        }

        /// <summary>
        /// 处理隐藏模态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected async Task HandleOnHideModal(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                ShowModals.Remove(id);
                await InvokeStateHasChangedAsync();
            }
        }
    }
}
