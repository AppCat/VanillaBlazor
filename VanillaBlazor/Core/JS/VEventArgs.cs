using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 事件传递参数基础
    /// </summary>
    public abstract class VEventArgs
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; }
    }
}
