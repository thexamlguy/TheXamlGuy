﻿using System;

namespace TheXamlGuy.Framework.Core
{
    public interface IDisposer
    {
        void Add(object subject, params object[] objects);

        TDisposable Replace<TDisposable>(object subject, IDisposable disposer, TDisposable replacement) where TDisposable : IDisposable;

        void Remove(object subject, IDisposable disposer);

        void Dispose(object subject);
    }
}
