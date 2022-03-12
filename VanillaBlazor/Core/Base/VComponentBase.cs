using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 组件基础
    /// </summary>
    public abstract class VComponentBase : ComponentBase, IAsyncDisposable
    {
        #region Parameter

        /// <summary>
        /// Id
        /// </summary>
        [Parameter]
        public string Id { get; set; }

        /// <summary>
        /// 类
        /// </summary>
        [Parameter]
        public string Class
        {
            get => _class;
            set
            {
                _class = value;
                ClassMapper.Original = value;
            }
        }
        private string _class;

        /// <summary>
        /// 样式
        /// </summary>
        [Parameter]
        public string Style
        {
            get => _style;
            set
            {
                _style = value;
                StyleMapper.Original = value;
                this.StateHasChanged();
            }
        }
        private string _style;

        /// <summary>
        /// 禁用
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; }

        /// <summary>
        /// 顺序
        /// </summary>
        [Parameter]
        public int? Tabindex { get; set; }

        /// <summary>
        /// 特性
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

        #endregion

        /// <summary>
        /// Js运行时
        /// </summary>
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        /// <summary>
        /// 类映射
        /// </summary>
        internal Mapper ClassMapper { get; set; } = new Mapper();

        /// <summary>
        /// 样式映射
        /// </summary>
        internal Mapper StyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 是否释放
        /// </summary>
        protected bool IsDisposed { get; private set; }

        /// <summary>
        /// 设置
        /// </summary>
        protected virtual void OnSet() { }

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Id ??= $"vb-{Guid.NewGuid().ToString("N")}";
            OnSet();
        }

        /// <summary>
        /// 调用状态改变 / 通知渲染
        /// </summary>
        protected void InvokeStateHasChanged()
        {
            InvokeAsync(() =>
            {
                if (!IsDisposed)
                {
                    StateHasChanged();
                }
            });
        }

        /// <summary>
        /// 调用状态改变异步 / 通知渲染
        /// </summary>
        /// <returns></returns>
        protected async Task InvokeStateHasChangedAsync()
        {
            await InvokeAsync(() =>
            {
                if (!IsDisposed)
                {
                    StateHasChanged();
                }
            });
        }

        /// <summary>
        /// Js调用异步
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="code"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected ValueTask<T> JsInvokeAsync<T>(string code, params object[] args)
        {
            return JSRuntime.InvokeAsync<T>(code, args);
        }

        /// <summary>
        /// Js调用异步
        /// </summary>
        /// <param name="code"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected ValueTask JsInvokeAsync(string code, params object[] args)
        {
            return JSRuntime.InvokeVoidAsync(code, args);
        }
        /// <summary>
        /// 释放
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed) return;

            IsDisposed = true;
        }

        /// <summary>
        /// 释放
        /// </summary>
        /// <returns></returns>
        public ValueTask DisposeAsync()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            return ValueTask.CompletedTask;
        }
    }
}
