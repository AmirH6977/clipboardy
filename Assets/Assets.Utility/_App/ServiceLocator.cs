﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Utility {
    public class ServiceLocator {
        public static ServiceLocatorAdapter Current;
        public ServiceLocator(IServiceCollection services) {
            Current = new ServiceLocatorAdapter(services);
        }
    }
    public class ServiceLocatorAdapter {
        private readonly ServiceProvider _serviceProvider;
        public ServiceLocatorAdapter(IServiceCollection services) {
            _serviceProvider = services.BuildServiceProvider();
        }
        public T GetInstance<T>() {
            return _serviceProvider.GetService<T>();
        }
    }
}
