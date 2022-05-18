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
    /// 长按按钮
    /// </summary>
    public partial class VLongPressButton : VButton
    {
        /// <summary>
        /// 目标时间
        /// </summary>
        protected DateTime Terminus { get; set; }

        /// <summary>
        /// 计时Task
        /// </summary>
        protected Task? TimeTask { get; set; }

        /// <summary>
        /// 计时Task 取消源
        /// </summary>
        protected CancellationTokenSource? TokenSource { get; set; }

        /// <summary>
        /// 是否上台
        /// </summary>
        protected bool IsMouseup { get; set; } = false;

        /// <summary>
        /// 设置
        /// </summary>
        protected override void OnSet()
        {
            base.OnSet();

            StyleMapper.Clear()
            .Add("position", "relative");
            ;
        }

        /// <summary>
        /// 内容渲染
        /// </summary>
        /// <returns></returns>
        protected override RenderFragment ContentFragment() => __builder =>
        {
            var sequence = 0;

            if (Element != null)
            {
                __builder.OpenElement(sequence++, Element.ToClass());
            }
            else
            {
                __builder.OpenElement(sequence++, "button");
            }

            __builder.AddComponent(ref sequence, this);
            __builder.IfAddAttribute(ref sequence, "type", InputType, () => !string.IsNullOrWhiteSpace(InputType));
            __builder.AddEvent(ref sequence, "onclick", HandleOnClickAsync, OnClickStopPropagation);
            __builder.AddEvent(ref sequence, "onmouseout", HandleOnMouseupAsync);
            __builder.AddEvent(ref sequence, "onmousedown", HandleOnMousedownAsync, OnMousedownStopPropagation);
            __builder.AddEvent(ref sequence, "onmouseup", HandleOnMouseupAsync, OnMouseupStopPropagation);

            if (Processing)
            {
                if (Height != null && Width != null)
                {
                    var top = ((Height ?? 0) - (decimal)24.2) / 2;
                    top = top <= 0 ? 0 : top;
                    __builder.AddContent(sequence++, new MarkupString($"<div style='width: {Width}px; height: {Height}px;'><i style='top: {top}px;' class='p-icon--spinner u-animation--spin'></i></div>"));
                }
                else
                {
                    __builder.AddContent(sequence++, new MarkupString("<i class='p-icon--spinner u-animation--spin'></i>"));
                }
            }
            else
            {
                __builder.EitherOrAddContent(ref sequence, ChildContent, Content, () => ChildContent != null);
            }

            RenderFragment progress = __builder =>
            {
                var sequence = 0;

                __builder.OpenComponent<VProgressBar>(sequence++);


                var barConfig = new VSonComponentConfig();

                barConfig.AddIfStyle("transition", $"width {((double)Delay + (double)Delay / 30) / 1000}s", () => !IsMouseup);
                barConfig.AddStyle("transition-duration", "none");
                barConfig.AddStyle("border-radius", "0px");
                barConfig.AddStyle("height", ".25em");

                __builder.AddAttribute(sequence++, "Style", $"position: absolute; margin: 0; left: 0px; bottom: 0px; width: 100%; border-radius: 0px;");
                __builder.AddAttribute(sequence++, nameof(VProgressBar.BarConfig), barConfig);
                __builder.AddAttribute(sequence++, nameof(VProgressBar.MaxValue), (uint?)100);
                __builder.AddAttribute(sequence++, nameof(VProgressBar.Value), (uint?)5);
                __builder.AddAttribute(sequence++, nameof(VProgressBar.Appearance), ProgressAppearance);
                __builder.IfAddAttribute(ref sequence, nameof(VProgressBar.Value), (uint?)100, () => TimeTask != null && !IsMouseup);

                __builder.CloseComponent();
            };

            __builder.AddContent(sequence++, progress);

            __builder.CloseComponent();
        };

        #region Event

        /// <summary>
        /// 处理点击
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected override Task HandleOnClickAsync(MouseEventArgs args)
        {
            if (!OnClickStop)
                return base.HandleOnClickAsync(args);
            else
                return Task.CompletedTask;
        }

        /// <summary>
        /// 处理鼠标按钮被按下。
        /// </summary>
        /// <param name="args"></param>
        private async Task HandleOnMousedownAsync(MouseEventArgs args)
        {
            await Run(args);
        }

        /// <summary>
        /// 处理鼠标按键被松开。
        /// </summary>
        /// <param name="args"></param>
        private async Task HandleOnMouseupAsync(MouseEventArgs args)
        {
            await Cancel();
        }

        /// <summary>
        /// 处理鼠标移走
        /// </summary>
        /// <param name="args"></param>
        protected async Task HandleOnMouseoutAsync(FocusEventArgs args)
        {
            await Cancel();
        }

        #endregion

        /// <summary>
        /// 运行
        /// </summary>
        /// <param name="args"></param>
        protected virtual async Task Run(MouseEventArgs args)
        {
            if (Processing)
                return;
            IsMouseup = false;
            await InvokeStateHasChangedAsync();
            var delay = DelayTimeSpan ?? TimeSpan.FromMilliseconds(Delay);
            Terminus = DateTime.Now.Add(delay);
            TokenSource = new CancellationTokenSource(delay);
            var totalMilliseconds = delay.TotalMilliseconds;
            TimeTask?.Dispose();
            TimeTask = Task.Run(async () =>
            {
                while (DateTime.Now < Terminus && !TokenSource.IsCancellationRequested)
                {
                    await Task.Delay(1);
                }
                if (!IsMouseup)
                {
                    await InvokeStateHasChangedAsync();
                    await Click(args);
                    await Cancel();
                }
            }, TokenSource.Token);
            await Task.CompletedTask;
        }

        /// <summary>
        /// 取消
        /// </summary>
        protected virtual async Task Cancel()
        {
            if (Processing)
                return;
            IsMouseup = true;
            TokenSource?.Cancel();
            Terminus = DateTime.MinValue;
            await InvokeStateHasChangedAsync();
        }
    }
}
