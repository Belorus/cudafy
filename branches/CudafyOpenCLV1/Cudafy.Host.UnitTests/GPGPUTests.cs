﻿/*
CUDAfy.NET - LGPL 2.1 License
Please consider purchasing a commerical license - it helps development, frees you from LGPL restrictions
and provides you with support.  Thank you!
Copyright (C) 2011 Hybrid DSP Systems
http://www.hybriddsp.com

This library is free software; you can redistribute it and/or
modify it under the terms of the GNU Lesser General Public
License as published by the Free Software Foundation; either
version 2.1 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public
License along with this library; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cudafy.Types;
using Cudafy.Host;
using Cudafy.UnitTests;
using NUnit.Framework;
using Cudafy.Translator;
namespace Cudafy.Host.UnitTests
{
    [TestFixture]
    public class GPGPUTests : CudafyUnitTest, ICudafyUnitTest
    {
        private CudafyModule _cm;

        private GPGPU _gpu;

        [TestFixtureSetUp]
        public void SetUp()
        {
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
        }

        [Test]
        public void Test_CreateCudaGPU()
        {
            GPGPU gpu = CudafyHost.GetDevice(eGPUType.Cuda);
            Assert.IsTrue(gpu is CudaGPU);
            gpu = null;
        }

        [Test]
        public void Test_CreateEmulatedGPU()
        {
            GPGPU gpu = CudafyHost.GetDevice(eGPUType.Emulator);
            Assert.IsTrue(gpu is EmulatedGPU);
            gpu = null;
        }



        //[Test]
        //[ExpectedException(typeof(CudafyHostException), ExpectedMessage=CudafyHostException.csDEVICE_ID_OUT_OF_RANGE)]
        //public void Test_TryCreateOutOfRangeCudaGPU()
        //{
        //    GPGPU gpu = CudafyHost.GetDevice(eGPUType.Cuda, 500);
        //}

        [Test]
        public void Test_GetCudaDeviceCount()
        {
            int cnt = CudafyHost.GetDeviceCount(eGPUType.Cuda);
            Console.WriteLine("Cuda device count = {0}", cnt);
            Assert.True(cnt > 0);
        }

        [Test]
        public void Test_GetEmulatedDeviceCount()
        {
            int cnt = CudafyHost.GetDeviceCount(eGPUType.Emulator);
            Console.WriteLine("Emulated device count = {0}", cnt);
            Assert.True(cnt > 0);
        }

        [Test]
        public void Test_GetCudaDeviceProps()
        {
            List<GPGPUProperties> props = CudafyHost.GetDeviceProperties(eGPUType.Cuda, false).ToList();
            int cnt = CudafyHost.GetDeviceCount(eGPUType.Cuda);
            Assert.AreEqual(cnt, props.Count);
            Assert.AreEqual(0, props[0].DeviceId);
            Assert.AreEqual(false, props[0].IsSimulated);
            Assert.AreEqual(false, props[0].Integrated);
            Assert.AreEqual(false, props[0].UseAdvanced);
            Assert.IsTrue(props[0].MultiProcessorCount == 0);
        }

        [Test]
        public void Test_GetEmulatedDeviceProps()
        {
            List<GPGPUProperties> props = CudafyHost.GetDeviceProperties(eGPUType.Emulator, false).ToList();
            int cnt = CudafyHost.GetDeviceCount(eGPUType.Emulator);
            Assert.AreEqual(cnt, props.Count);
            Assert.AreEqual(0, props[0].DeviceId);
            Assert.AreEqual(true, props[0].IsSimulated);
            Assert.AreEqual(false, props[0].Integrated);
            Assert.AreEqual(false, props[0].UseAdvanced);
            Assert.IsTrue(props[0].MultiProcessorCount == 0);
        }




        public void TestSetUp()
        {

        }

        public void TestTearDown()
        {

        }

        void ICudafyUnitTest.SetUp()
        {
   
        }

        void ICudafyUnitTest.TearDown()
        {
   
        }

        void ICudafyUnitTest.TestSetUp()
        {
    
        }

        void ICudafyUnitTest.TestTearDown()
        {
       
        }
    }
}
