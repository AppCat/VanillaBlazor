using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 用于 Enum implicit operator 的 过度类
    /// An overclass for Enum Implicit Operator
    /// </summary>
    public class EnumMix<TEnum> where TEnum : Enum
    {
        /// <summary>
        /// 值
        /// </summary>
        public TEnum Value { get; }

        /// <summary>
        /// 用于 Enum implicit operator 的 过度类
        /// An overclass for Enum Implicit Operator
        /// </summary>
        /// <param name="value"></param>
        public EnumMix(TEnum value)
        {
            Value = value;
        }

        /// <summary>
        /// int To
        /// </summary>
        /// <param name="number"></param>
        public static implicit operator EnumMix<TEnum>(int number)
        {
            return new EnumMix<TEnum>((TEnum)Enum.ToObject(typeof(TEnum), number));
        }

        /// <summary>
        /// string To
        /// </summary>
        /// <param name="name"></param>
        public static implicit operator EnumMix<TEnum>(string name)
        {
            return new EnumMix<TEnum>((TEnum)Enum.Parse(typeof(TEnum), name, true));
        }

        /// <summary>
        /// enum To
        /// </summary>
        /// <param name="enum"></param>
        public static implicit operator EnumMix<TEnum>(TEnum @enum)
        {
            return new EnumMix<TEnum>(@enum);
        }
    }
}
