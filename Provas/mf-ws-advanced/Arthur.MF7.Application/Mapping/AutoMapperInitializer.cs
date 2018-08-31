﻿using AutoMapper;
using System.Diagnostics.CodeAnalysis;

namespace Arthur.MF7.Application.Mapping
{
    [ExcludeFromCodeCoverage]
    public class AutoMapperInitializer
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(typeof(AutoMapperInitializer));
            });
        }

        public static void Reset()
        {
            Mapper.Reset();
        }
    }
}
