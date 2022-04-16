using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanillaBlazor.Extensions;

namespace VanillaBlazor
{
    /// <summary>
    /// 模态组件可以用来覆盖屏幕上包含提示、对话或交互的区域。  
    /// The modal component can be used to overlay an area of the screen which can contain a prompt, dialog or interaction.
    /// </summary>
    public partial class VModal : VComponentBase
    {
        /// <summary>
        /// 可见
        /// The visibility is config for the modal.
        /// </summary>
        public bool Visibility { get; private set; }

        /// <summary>
        /// 设置
        /// </summary>
        protected override void OnSet()
        {
            var fixedClass = "p-modal__dialog";
            ClassMapper.Clear()
            .Add(fixedClass)
            ;
        }

        /// <summary>
        /// 参数设置
        /// </summary>
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            HeaderConfig = HeaderConfig.Copy();
            HeaderConfig.AddClass("p-modal__header");

            TitleConfig = TitleConfig .Copy();
            TitleConfig.AddClass("p-modal__title");

            ContentConfig = ContentConfig.Copy();
            ContentConfig.AddClass("p-modal__content");

            FooterConfig = FooterConfig.Copy();
            FooterConfig.AddClass("p-modal__footer");
        }

        /// <summary>
        /// 内容
        /// </summary>
        /// <returns></returns>
        private RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            __builder.OpenElement(sequence++, "div");
            __builder.AddAttribute(sequence++, "class", "p-modal");
            __builder.AddAttribute(sequence++, "id", $"{Id}-modal");

            if (Visibility)
            {
                __builder.AddAttribute(sequence++, "style", "display: flex;");
            }
            else
            {
                __builder.AddAttribute(sequence++, "style", "display: none;");
            }

            __builder.OpenElement(sequence++, "section");

            __builder.AddComponent(ref sequence, this);
            __builder.AddAttribute(sequence++, "role", "dialog");
            __builder.AddAttribute(sequence++, "aria-modal", "true");
            __builder.AddAttribute(sequence++, "aria-labelledby", "modal-title");
            __builder.AddAttribute(sequence++, "aria-describedby", "modal-description");

            RenderFragment header = __builder =>
            {
                var sequence = 0;
                __builder.OpenElement(sequence++, "header");
                __builder.AddConfig(ref sequence, HeaderConfig);

                __builder.OpenElement(sequence++, "div");
                __builder.AddConfig(ref sequence, TitleConfig);

                if (TitleTemplate != null)
                {
                    __builder.AddContent(sequence++, TitleTemplate, Model);
                }
                else
                {
                    __builder.AddContent(sequence++, Title);
                }

                __builder.CloseElement();

                RenderFragment close = __builder =>
                {
                    __builder.OpenElement(sequence++, "button");
                    __builder.AddAttribute(sequence++, "class", $"p-modal__close");
                    __builder.AddAttribute(sequence++, "aria-label", "Close active modal");
                    __builder.AddAttribute(sequence++, "aria-controls", $"{Id}-modal");
                    __builder.AddEvent(ref sequence, "onclick", async () => await HideAsync(false), true);
                    __builder.AddContent(sequence++, "Close");
                    __builder.CloseComponent();
                };

                //__builder.AddContent(sequence++, new MarkupString("<button class='p-modal__close' aria-label='Close active modal' aria-controls='modal'>Close</button>"));
                __builder.AddContent(sequence++, close);
                __builder.CloseComponent();
            };

            RenderFragment content = __builder =>
            {
                var sequence = 0;
                __builder.OpenElement(sequence++, "content");
                __builder.AddConfig(ref sequence, ContentConfig);

                if (ContentTemplate != null)
                {
                    __builder.AddContent(sequence++, ContentTemplate, Model);
                }
                else
                {
                    __builder.AddContent(sequence++, new MarkupString($"<p>{Content}</p>"));
                }

                __builder.CloseComponent();
            };

            RenderFragment footer = __builder =>
            {
                var sequence = 0;
                __builder.OpenElement(sequence++, "footer");
                __builder.AddConfig(ref sequence, FooterConfig);

                if (FooterTemplate != null)
                {
                    __builder.AddContent(sequence++, FooterTemplate, Model);
                }
                else
                {
                    RenderFragment button(VModalActionModalConfig config) => __builder =>
                    {
                        __builder.OpenComponent<VButton>(sequence++);
                        __builder.AddConfig(ref sequence, config);
                        __builder.AddAttribute(sequence++, "Appearance", config.Appearance);
                        __builder.AddAttribute(sequence++, "Content", config.Text);
                        __builder.IfAddAttribute(ref sequence, "OnClick", EventCallback.Factory.Create<MouseEventArgs>(this, async e =>
                        {
                            var isHide = await config.OnClick.Invoke(Model);

                            if (isHide && Visibility)
                            {
                                await HideAsync(false);
                            }

                        }), () => config.OnClick != null);

                        __builder.AddAttribute(sequence++, "class", $"u-no-margin--bottom {config.AsClass}");
                        __builder.CloseComponent();
                    };

                    foreach (var action in Actions)
                    {
                        __builder.AddContent(sequence++, button(action));
                    }
                }

                __builder.CloseComponent();
            };

            __builder.AddContent(sequence++, header);
            __builder.AddContent(sequence++, content);
            __builder.AddContent(sequence++, footer);

            __builder.CloseElement();

            __builder.CloseComponent();
        };

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="isStateHasChanged"></param>
        /// <returns></returns>
        public async Task ShowAsync(bool isStateHasChanged = true)
        {
            Visibility = true;
            await OnShow.InvokeAsync();

            if (isStateHasChanged)
            {
                await InvokeStateHasChangedAsync();
            }
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public async Task HideAsync(bool isStateHasChanged = true)
        {
            Visibility = false;
            await OnHidden.InvokeAsync();

            if (isStateHasChanged)
            {
                await InvokeStateHasChangedAsync();
            }
        }
    }
}
