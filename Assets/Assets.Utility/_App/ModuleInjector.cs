﻿using Microsoft.Extensions.DependencyInjection;
using Assets.Model.Settings;
using Assets.Utility.Infrastructure;

namespace Assets.Utility {
    public class ModuleInjector {
        public static void Inject(IServiceCollection services, AppSetting appSetting = null) {
            services.AddScoped<Cryptograph>();
            services.AddScoped<CompressionHandler>();
            services.AddSingleton<PropertyMapper>();
            services.AddSingleton<RandomMaker>();
        }
    }
}
