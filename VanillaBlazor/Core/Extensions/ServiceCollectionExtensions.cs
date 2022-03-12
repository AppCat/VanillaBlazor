using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaBlazor.Extensions
{
    /// <summary>
    /// 服务扩展
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection AddVanillaBlazor(this IServiceCollection services)
        {

            return services;
        }
    }
}
