﻿using Effort.Provider;
using NUnit.Framework;

namespace Arthur.MF7.Infra.ORM.Tests.Initializer
{
    [TestFixture]
    public class EffortTestBase
    {
        [OneTimeSetUp]
        public void InitializeOneTime()
        {
            EffortProviderConfiguration.RegisterProvider();
        }

        [SetUp]
        public void Initialize()
        {
            EffortProviderFactory.ResetDb();
        }
    }
}
