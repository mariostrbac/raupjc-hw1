﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using zad03;

namespace zad03Test
{
    [TestClass]
    public class Assignment3Tests
    {
        [TestMethod]
        public void Enumerable_10Points()
        {
            IGenericList<int> list = new GenericList<int>();

            for (int i = 0; i < 100; i++)
            {
                list.Add(-i);
            }

            foreach (var i in list)
            {
                Assert.AreEqual(i, list.GetElement(-i));
            }
        }
    }
}
