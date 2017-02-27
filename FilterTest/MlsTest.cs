﻿using System;
using System.Linq;
using Filter.Algorithms;
using Filter.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestExtensions;

namespace FilterTest
{
    [TestClass]
    public class MlsTest
    {
        //[TestMethod]
        public void TestMls()
        {
            for (int i = 2; i < SignalGenerators.MlsFeedbackTaps.Count; i++)
            {
                var sequence = SignalGenerators.GenerateMls(i);

                Assert.IsTrue(sequence.Count() == Math.Pow(2, i) - 1);
            }

            ThrowsAssert.Throws<ArgumentOutOfRangeException>(() => SignalGenerators.GenerateMls(1).ToReadOnlyList());
            ThrowsAssert.Throws<ArgumentOutOfRangeException>(() => SignalGenerators.GenerateMls(SignalGenerators.MlsFeedbackTaps.Count).ToReadOnlyList());
        }
    }
}