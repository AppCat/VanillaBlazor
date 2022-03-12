using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 映射
    /// </summary>
    public class Mapper
    {
        /// <summary>
        /// 映射表
        /// </summary>
        private readonly Dictionary<Func<string>, Func<bool>> _map = new();

        /// <summary>
        /// 结果
        /// </summary>
        public string Result => AsString();

        /// <summary>
        /// 原始
        /// </summary>
        internal string Original { get; set; }

        /// <summary>
        /// 映射
        /// </summary>
        public Mapper()
        {
            Clear();
        }

        /// <summary>
        /// 作为字符串
        /// </summary>
        /// <returns></returns>
        public string AsString()
        {
            return string.Join(" ", _map.Where(i => i.Value()).Select(i => i.Key()));
        }

        /// <summary>
        /// 转字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return AsString();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Mapper Add(string name)
        {
            _map.Add(() => name, () => true);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="funcName"></param>
        /// <returns></returns>
        public Mapper Get(Func<string> funcName)
        {
            _map.Add(funcName, () => true);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="funcName"></param>
        /// <returns></returns>
        public Mapper Get<TEnum>(EnumMix<TEnum>? funcName = null)
            where TEnum : Enum
        {
            _map.Add(() => funcName.ToClass(), () => funcName != null);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="funcName"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public Mapper GetIf(Func<string> funcName, Func<bool> func)
        {
            _map.Add(funcName, func);
            return this;
        }

        /// <summary>
        /// 如果添加
        /// </summary>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public Mapper If(string name, Func<bool> func)
        {
            _map.Add(() => name, func);
            return this;
        }

        /// <summary>
        /// 清空
        /// </summary>
        /// <returns></returns>
        public Mapper Clear()
        {
            _map.Clear();

            _map.Add(() => Original, () => !string.IsNullOrEmpty(Original));

            return this;
        }
    }
}
