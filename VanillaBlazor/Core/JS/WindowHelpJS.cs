using Microsoft.JSInterop;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// Window 帮助
    /// </summary>
    public class WindowHelpJS
    {
        private readonly Lazy<Task<IJSObjectReference>> _moduleTask;
        private readonly Dictionary<string, (Type argsType, List<(VComponentBase component, Action<object>, int)>)> _eventListeners;

        /// <summary>
        /// 元素帮助JS
        /// </summary>
        /// <param name="jsRuntime"></param>
        public WindowHelpJS(IJSRuntime jsRuntime)
        {
            _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/VanillaBlazor/js/windowHelp.js").AsTask());
            _eventListeners = new Dictionary<string, (Type argsType, List<(VComponentBase component, Action<object>, int)>)>();
        }

        /// <summary>
        /// 添加事件监听
        /// </summary>
        /// <typeparam name="TComponent"></typeparam>
        /// <typeparam name="TEventArgs"></typeparam>
        /// <param name="component"></param>
        /// <param name="type"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task AddEventListenerAsync<TComponent, TEventArgs>(TComponent component, string type, Action<TEventArgs> callback)
            where TComponent : VComponentBase
            where TEventArgs : VEventArgs
        {

            //if (!_eventListeners.ContainsKey(type))
            //{
            //    _eventListeners.TryAdd(type, new Dictionary<string, (VComponentBase component, Type argsType, List<(Action<object>, int)> callbacks)>());
            //}
            //_eventListeners[type].TryAdd(component.Id, (component, typeof(TEventArgs), new List<(Action<object>, int)>()));
            //var callbacks = _eventListeners[type][component.Id].callbacks;
            //if (!callbacks.Any(callback => callback.Item2 == callback.GetHashCode()))
            //{
            //    _eventListeners[type][component.Id].callbacks.Add((args => callback.Invoke((TEventArgs)args), callback.GetHashCode()));
            //    var module = await _moduleTask.Value;
            //    await module.InvokeVoidAsync("addEventListener", type, component.Id);
            //}

            await Task.CompletedTask;
        }

        /// <summary>
        /// 删除事件监听
        /// </summary>
        /// <typeparam name="TComponent"></typeparam>
        /// <param name="component"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task RemoveEventListenerAsync<TComponent>(TComponent component, string type)
            where TComponent : VComponentBase
        {
            //var module = await _moduleTask.Value;
            //await module.InvokeVoidAsync("removeEventListener", type, component.Id);

            await Task.CompletedTask;
        }

        #region JSInvokable

        /// <summary>
        /// 事件回调
        /// </summary>
        /// <param name="type"></param>
        /// <param name="eventArgs"></param>
        /// <returns></returns>
        [JSInvokable]
        public static async Task OnWindowEventCallBack(string type, object eventArgs)
        {
            try
            {
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion
    }
}
