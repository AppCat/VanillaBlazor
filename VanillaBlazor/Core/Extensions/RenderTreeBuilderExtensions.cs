using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class RenderTreeBuilderExtensions
    {
        /// <summary>
        /// 添加组件
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="sequence"></param>
        /// <param name="component"></param>
        /// <returns></returns>
        public static RenderTreeBuilder AddComponent(this RenderTreeBuilder builder, ref int sequence, VComponentBase component)
        {
            if(component != null)
            {
                builder.IfAddAttribute(ref sequence, "class", component.ClassMapper.Result, () => !string.IsNullOrWhiteSpace(component.ClassMapper.Result));
                builder.IfAddAttribute(ref sequence, "style", component.StyleMapper.Result, () => !string.IsNullOrWhiteSpace(component.StyleMapper.Result));
                builder.AddAttribute(sequence++, "id", component.Id);
                builder.AddAttribute(sequence++, "tabindex", component.Tabindex);
                builder.IfAddAttribute(ref sequence, "disabled", String.Empty, () => component.Disabled);

                if(component.Attributes != null && component.Attributes.Any())
                {
                    foreach (var attribute in component.Attributes)
                    {
                        if(attribute.Value == null)
                        {
                            builder.AddAttribute(sequence++, attribute.Key);
                        }
                        else
                        {
                            builder.AddAttribute(sequence++, attribute.Key, attribute.Value);
                        }
                    }
                }
            }

            return builder;
        }

        /// <summary>
        /// 添加配置
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="sequence"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static RenderTreeBuilder AddConfig(this RenderTreeBuilder builder, ref int sequence, VSonComponentConfig config)
        {
            if (config != null)
            {
                builder.IfAddAttribute(ref sequence, "class", config.AsClass, () => !string.IsNullOrWhiteSpace(config.AsClass));
                builder.IfAddAttribute(ref sequence, "style", config.AsStyle, () => !string.IsNullOrWhiteSpace(config.AsStyle));
                builder.IfAddAttribute(ref sequence, "attributes", config.Attributes, () => config.Attributes != null && config.Attributes.Any());
            }
            return builder;
        }

        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="sequence"></param>
        /// <param name="eventName"></param>
        /// <param name="value"></param>
        /// <param name="stopPropagation"></param>
        /// <param name="preventDefault"></param>
        /// <returns></returns>
        public static RenderTreeBuilder AddEvent(this RenderTreeBuilder builder, ref int sequence, string eventName, MulticastDelegate? value, bool? stopPropagation = null, bool? preventDefault = null)
        {
            builder.AddAttribute(sequence++, eventName, value);

            if(stopPropagation != null)
            {
                builder.AddEventStopPropagationAttribute(sequence++, eventName, (bool)stopPropagation);
            }

            if (preventDefault != null)
            {
                builder.AddEventPreventDefaultAttribute(sequence++, eventName, (bool)preventDefault);
            }

            return builder;
        }

        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="sequence"></param>
        /// <param name="eventName"></param>
        /// <param name="value"></param>
        /// <param name="stopPropagation"></param>
        /// <param name="preventDefault"></param>
        /// <returns></returns>
        public static RenderTreeBuilder AddEvent<TArgument>(this RenderTreeBuilder builder, ref int sequence, string eventName, EventCallback<TArgument> value, bool? stopPropagation = null, bool? preventDefault = null)
        {
            builder.AddAttribute(sequence++, eventName, value);

            if (stopPropagation != null)
            {
                builder.AddEventStopPropagationAttribute(sequence++, eventName, (bool)stopPropagation);
            }

            if (preventDefault != null)
            {
                builder.AddEventStopPropagationAttribute(sequence++, eventName, (bool)preventDefault);
            }

            return builder;
        }

        /// <summary>
        /// 添加事件
        /// </summary>
        /// <typeparam name="TArgument"></typeparam>
        /// <param name="builder"></param>
        /// <param name="sequence"></param>
        /// <param name="eventName"></param>
        /// <param name="receiver"></param>
        /// <param name="callback"></param>
        /// <param name="stopPropagation"></param>
        /// <param name="preventDefault"></param>
        /// <returns></returns>
        public static RenderTreeBuilder AddEvent<TArgument>(this RenderTreeBuilder builder, ref int sequence, string eventName, object receiver, Func<TArgument, Task> callback, bool? stopPropagation = null, bool? preventDefault = null)
        {
            return AddEvent(builder, ref sequence, eventName, EventCallback.Factory.Create(receiver, callback), stopPropagation, preventDefault);
        }

        /// <summary>
        /// 添加事件
        /// </summary>
        /// <typeparam name="TArgument"></typeparam>
        /// <param name="builder"></param>
        /// <param name="sequence"></param>
        /// <param name="eventName"></param>
        /// <param name="receiver"></param>
        /// <param name="callback"></param>
        /// <param name="stopPropagation"></param>
        /// <param name="preventDefault"></param>
        /// <returns></returns>
        public static RenderTreeBuilder AddEvent<TArgument>(this RenderTreeBuilder builder, ref int sequence, string eventName, object receiver, Action<TArgument> callback, bool? stopPropagation = null, bool? preventDefault = null)
        {
            return AddEvent(builder, ref sequence, eventName, EventCallback.Factory.Create(receiver, callback), stopPropagation, preventDefault);
        }

        /// <summary>
        /// 判断是否添加
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="sequence"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static RenderTreeBuilder IfAddAttribute(this RenderTreeBuilder builder, ref int sequence, string name, string? value, Func<bool> func)
        {
            if(func?.Invoke() ?? false)
            {
                builder.AddAttribute(sequence++, name, value);
            }

            return builder;
        }

        /// <summary>
        /// 判断是否添加
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="sequence"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static RenderTreeBuilder IfAddAttribute(this RenderTreeBuilder builder, ref int sequence, string name, object? value, Func<bool> func)
        {
            if (func?.Invoke() ?? false)
            {
                builder.AddAttribute(sequence++, name, value);
            }

            return builder;
        }

        /// <summary>
        /// 判断是否添加
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="sequence"></param>
        /// <param name="fragment"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static RenderTreeBuilder IfAddContent(this RenderTreeBuilder builder, ref int sequence, RenderFragment? fragment, Func<bool> func)
        {
            if (func?.Invoke() ?? false)
            {
                builder.AddContent(sequence++, fragment);
            }

            return builder;
        }

        /// <summary>
        /// 判断是否添加
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="sequence"></param>
        /// <param name="fragment"></param>
        /// <param name="value"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static RenderTreeBuilder IfAddContent<TValue>(this RenderTreeBuilder builder, ref int sequence, RenderFragment<TValue>? fragment, TValue value, Func<bool> func)
        {
            if (func?.Invoke() ?? false)
            {
                builder.AddContent<TValue>(sequence++, fragment, value);
            }

            return builder;
        }

        /// <summary>
        /// 判断是否添加
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="sequence"></param>
        /// <param name="textContent"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static RenderTreeBuilder IfAddContent(this RenderTreeBuilder builder, ref int sequence, string? textContent, Func<bool> func)
        {
            if (func?.Invoke() ?? false)
            {
                builder.AddContent(sequence++, textContent);
            }

            return builder;
        }

        /// <summary>
        /// 二选一
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="sequence"></param>
        /// <param name="content1"></param>
        /// <param name="content2"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static RenderTreeBuilder EitherOrAddContent(this RenderTreeBuilder builder, ref int sequence, string? content1, string? content2, Func<bool> func)
        {
            if (func?.Invoke() ?? false)
            {
                builder.AddContent(sequence++, content1);
            }
            else
            {
                builder.AddContent(sequence++, content2);
            }

            return builder;
        }

        /// <summary>
        /// 二选一
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="sequence"></param>
        /// <param name="content1"></param>
        /// <param name="content2"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static RenderTreeBuilder EitherOrAddContent(this RenderTreeBuilder builder, ref int sequence, RenderFragment? content1, string? content2, Func<bool> func)
        {
            if (func?.Invoke() ?? false)
            {
                builder.AddContent(sequence++, content1);
            }
            else
            {
                builder.AddContent(sequence++, content2);
            }

            return builder;
        }

        /// <summary>
        /// 二选一
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="sequence"></param>
        /// <param name="content1"></param>
        /// <param name="content2"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static RenderTreeBuilder EitherOrAddContent(this RenderTreeBuilder builder, ref int sequence, string? content1, RenderFragment? content2, Func<bool> func)
        {
            if (func?.Invoke() ?? false)
            {
                builder.AddContent(sequence++, content1);
            }
            else
            {
                builder.AddContent(sequence++, content2);
            }

            return builder;
        }

        /// <summary>
        /// 二选一
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="sequence"></param>
        /// <param name="content1"></param>
        /// <param name="content2"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static RenderTreeBuilder EitherOrAddContent(this RenderTreeBuilder builder, ref int sequence, RenderFragment? content1, RenderFragment? content2, Func<bool> func)
        {
            if (func?.Invoke() ?? false)
            {
                builder.AddContent(sequence++, content1);
            }
            else
            {
                builder.AddContent(sequence++, content2);
            }

            return builder;
        }

        /// <summary>
        /// 打开级联
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="builder"></param>
        /// <param name="sequence"></param>
        /// <param name="value"></param>
        /// <param name="renderFragment"></param>
        /// <param name="name"></param>
        /// <param name="isFixed"></param>
        /// <returns></returns>
        public static RenderTreeBuilder AddCascadingValue<TValue>(this RenderTreeBuilder builder, 
            ref int sequence,
            TValue value,
            RenderFragment renderFragment,
            string? name = null, 
            bool? isFixed = null)
        {
            builder.OpenComponent<CascadingValue<TValue>>(sequence++);
            builder.AddAttribute(sequence++, nameof(CascadingValue<TValue>.Value), value);
            builder.IfAddAttribute(ref sequence, nameof(CascadingValue<TValue>.IsFixed), true, () => isFixed != null && isFixed == true);
            builder.IfAddAttribute(ref sequence, nameof(CascadingValue<TValue>.Name), name, () => !string.IsNullOrWhiteSpace(name));
            builder.AddAttribute(sequence++, nameof(CascadingValue<IVForm>.ChildContent), renderFragment);
            builder.CloseComponent();

            return builder;
        }

        ///// <summary>
        ///// 添加子内容
        ///// </summary>
        ///// <param name="builder"></param>
        ///// <param name="sequence"></param>
        ///// <param name="renderFragment"></param>
        ///// <returns></returns>
        //public static RenderTreeBuilder AddChildContent(this RenderTreeBuilder builder, ref int sequence, RenderFragment? renderFragment)
        //{
        //    builder.AddAttribute(sequence++, ChildContent, isFixed);

        //    return builder;
        //}

        /// <summary>
        /// The reserved parameter name used for supplying child content.
        /// </summary>
        private const string ChildContent = nameof(ChildContent);
    }
}
