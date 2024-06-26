﻿namespace TheXamlGuy.Framework.Core
{
    public static class IServiceFactoryExtensions
    {
        public static T? Get<T>(this IServiceFactory serviceFactory)
        {
            return serviceFactory.Get<T>(typeof(T));
        }

        public static T Create<T>(this IServiceFactory serviceFactory, params object?[] parameters)
        {
            return serviceFactory.Create<T>(typeof(T), parameters);
        }

        public static object? Create(this IServiceFactory serviceFactory, Type type)
        {
            ServiceFactoryDescriptor? descriptor = new(serviceFactory);
            return descriptor.Create(type);
        }
    }
}