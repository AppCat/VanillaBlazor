﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanillaBlazor.Services;

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
            // Service
            services.AddSingleton<VModalService>();

            // JS
            services.AddSingleton<ElementHelpJS>();
            services.AddSingleton<WindowHelpJS>();

            return services;
        }
    }
}
