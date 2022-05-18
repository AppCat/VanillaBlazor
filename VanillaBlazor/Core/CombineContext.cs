using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor
{
    /// <summary>
    /// 组合上下文
    /// </summary>
    public class CombineContext<TFather, TSon>
        where TFather : VComponentBase
        where TSon : VComponentBase
    {
        /// <summary>
        /// 父组件
        /// </summary>
        public TFather Father { get; }

        /// <summary>
        /// 子组件集
        /// </summary>
        public IList<TSon> Sons { get; }

        /// <summary>
        /// 组件上下文上下文
        /// </summary>
        /// <param name="father"></param>
        public CombineContext(TFather father)
        {
            Father = father;
            Sons = new List<TSon>();
        }

        /// <summary>
        /// 添加子组件
        /// </summary>
        /// <param name="son"></param>
        public void AddSon(TSon son)
        {
            if (son == null)
            {
                return;
            }
            Sons.Add(son);
        }
    }
}
