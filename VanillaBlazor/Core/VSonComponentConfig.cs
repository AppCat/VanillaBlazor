using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 子组件配置
    /// </summary>
    public class VSonComponentConfig
    {
        /// <summary>
        /// 空
        /// </summary>
        public static VSonComponentConfig Empty => new VSonComponentConfig();

        /// <summary>
        /// 样式
        /// </summary>
        internal string AsStyle { get => $"{StyleMapper.Result}{(!string.IsNullOrEmpty(Style) ? $" {Style}" : "")}"; }

        /// <summary>
        /// 样式
        /// </summary>
        public string? Style { get; set; }

        /// <summary>
        /// 样式映射器
        /// </summary>
        internal StyleMapper StyleMapper { get; set; } = new StyleMapper();

        /// <summary>
        /// 类
        /// </summary>
        internal string AsClass { get => $"{ClassMapper.Result}{(!string.IsNullOrEmpty(Class) ? $" {Class}" : "")}"; }

        /// <summary>
        /// 类
        /// </summary>
        public string? Class { get; set; }

        /// <summary>
        /// 类映射器
        /// </summary>
        internal ClassMapper ClassMapper { get; set; } = new ClassMapper();

        /// <summary>
        /// 显示部分特性
        /// </summary>
        public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// 子组件配置
        /// </summary>
        public VSonComponentConfig() { }

        /// <summary>
        /// 子组件配置
        /// </summary>
        /// <param name="config"></param>
        internal VSonComponentConfig(VSonComponentConfig config = null)
        {
            Class = config?.AsClass;
            Style = config?.AsStyle;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public VSonComponentConfig AddStyle(string name, string value)
        {
            StyleMapper.Add(name, value);
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public VSonComponentConfig AddStyle(string name, Func<string> value)
        {
            StyleMapper.AddGet(name, value);
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="allow"></param>
        /// <returns></returns>
        public VSonComponentConfig AddIfStyle(string name, string value, Func<bool> allow)
        {
            StyleMapper.AddIf(name, value, allow);
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="allow"></param>
        /// <returns></returns>
        public VSonComponentConfig AddIfStyle(string name, Func<string> value, Func<bool> allow)
        {
            StyleMapper.AddGetIf(name, value, allow);
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="class"></param>
        /// <returns></returns>
        public VSonComponentConfig AddClass(string @class)
        {
            ClassMapper.Add(@class);
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="class"></param>
        /// <returns></returns>
        public VSonComponentConfig AddClass(Func<string> @class)
        {
            ClassMapper.Get(@class);
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="class"></param>
        /// <param name="ifFunc"></param>
        /// <returns></returns>
        public VSonComponentConfig AddIfClass(string @class, Func<bool> ifFunc)
        {
            ClassMapper.If(@class, ifFunc);
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="class"></param>
        /// <param name="ifFunc"></param>
        /// <returns></returns>
        public VSonComponentConfig AddIfClass(Func<string> @class, Func<bool> ifFunc)
        {
            ClassMapper.GetIf(@class, ifFunc);
            return this;
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <returns></returns>
        public VSonComponentConfig Copy()
        {
            return new VSonComponentConfig
            {
                Style = this.Style,
                Class = this.Class,
                StyleMapper = this.StyleMapper.Copy(),
                ClassMapper = this.ClassMapper.Copy(),
                Attributes = new Dictionary<string, object>(this.Attributes)
            };
        }
    }
}
