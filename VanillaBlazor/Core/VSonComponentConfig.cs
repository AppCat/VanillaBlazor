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
        internal string AsStyle { get => $"{StyleMapper.Result} {Style}"; }

        /// <summary>
        /// 样式
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// 样式映射器
        /// </summary>
        internal Mapper StyleMapper { get; set; } = new Mapper();

        /// <summary>
        /// 类
        /// </summary>
        internal string AsClass { get => $"{ClassMapper.Result} {Class}"; }

        /// <summary>
        /// 类
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// 类映射器
        /// </summary>
        internal Mapper ClassMapper { get; set; } = new Mapper();

        /// <summary>
        /// 显示部分特性
        /// </summary>
        public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public VSonComponentConfig AddStyle(string style)
        {
            StyleMapper.Add(style);
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public VSonComponentConfig AddStyle(Func<string> style)
        {
            StyleMapper.Get(style);
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="style"></param>
        /// <param name="ifFunc"></param>
        /// <returns></returns>
        public VSonComponentConfig AddIfStyle(string style, Func<bool> ifFunc)
        {
            StyleMapper.If(style, ifFunc);
            return this;
        }

        /// <summary>
        /// 添加样式
        /// </summary>
        /// <param name="style"></param>
        /// <param name="ifFunc"></param>
        /// <returns></returns>
        public VSonComponentConfig AddIfStyle(Func<string> style, Func<bool> ifFunc)
        {
            StyleMapper.GetIf(style, ifFunc);
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
    }
}
