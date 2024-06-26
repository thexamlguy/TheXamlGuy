﻿using System.IO.Ports;
using TheXamlGuy.Framework.Core;

namespace TheXamlGuy.Framework.Serial;

public class SerialFactory : ISerialFactory
{
    private readonly IServiceFactory factory;
    private readonly Dictionary<ISerialConfiguration, ISerialContext> cache = new();

    public SerialFactory(IServiceFactory factory)
    {
        this.factory = factory;
    }

    public ISerialContext<TSerialReader, TContent> Create<TSerialReader, TContent>(ISerialConfiguration configuration) where TSerialReader : SerialReader<TContent>
    {
        if (cache.TryGetValue(configuration, out ISerialContext? context))
        {
            return (ISerialContext<TSerialReader, TContent>)context;
        }

        SerialPort serialPort = new(configuration.PortName, configuration.BaudRate)
        {
            DtrEnable = true
        };
        
        SerialConnection connection = new(serialPort);
        SerialStreamer streamer = new(serialPort);

        context = factory.Create<SerialContext<TSerialReader, TContent>>(connection, streamer);
        cache.Add(configuration, context);

        return (ISerialContext<TSerialReader, TContent>)context;
    }
}
