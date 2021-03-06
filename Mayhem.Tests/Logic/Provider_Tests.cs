﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mayhem.DTO;
using Mayhem.Logic;

namespace Mayhem.Tests.Logic
{
    [TestClass]
    public class Provider_Tests
    {
        private Channel GetChannel(string channelName, List<Channel> channels)
        {
            Channel returnValue = null;
            foreach (Channel channel in channels)
            {
                
                if (channelName == channel.ChannelName)
                {
                    returnValue = channel;
                }
            }
            return returnValue;
        }

        private Dispatcher GetDispatcher(string dispatcherId, List<Dispatcher> dispatchers)
        {
            Dispatcher returnValue = null;
            foreach (Dispatcher dispatcher in dispatchers)
            {
                if (dispatcherId == dispatcher.DispatcherId)
                {
                    returnValue = dispatcher;
                }
            }
            return returnValue;
        }

        [TestMethod]
        public void Channel_Tests()
        {
            Channel channel1 = new Channel();
            channel1.ChannelName = "Channel 3";
            Provider.CreateChannel(channel1.ChannelName);

            Channel channel2 = new Channel();
            channel2.ChannelName = "Channel C";
            Provider.CreateChannel(channel2.ChannelName);

            List<Channel> channels = Provider.GetChannels();
            channel1 = GetChannel(channel1.ChannelName, channels);
            Assert.IsTrue(channels.Contains(channel1));
            channel2 = GetChannel(channel2.ChannelName, channels);
            Assert.IsTrue(channels.Contains(channel2));
        }

        [TestMethod]
        public void Dispatcher_Tests()
        {
            Dispatcher dispatcher1 = new Dispatcher();
            dispatcher1.DispatcherId = "1234lop";
            dispatcher1.FirstName = "Eric";
            dispatcher1.LastName = "Fayad";
            dispatcher1.RoleTypeId = 1;
            Provider.CreateDispatcher(dispatcher1);

            Dispatcher dispatcher2 = new Dispatcher();
            dispatcher2.DispatcherId = "543opt";
            dispatcher2.FirstName = "Christian";
            dispatcher2.LastName = "Maggiora";
            dispatcher2.RoleTypeId = 2;
            Provider.CreateDispatcher(dispatcher2);

            List<Dispatcher> dispatcherList = Provider.GetDispatchers();
            dispatcher1 = GetDispatcher(dispatcher1.DispatcherId, dispatcherList);
            Assert.IsTrue(dispatcherList.Contains(dispatcher1));
            dispatcher2 = GetDispatcher(dispatcher2.DispatcherId, dispatcherList);
            Assert.IsTrue(dispatcherList.Contains(dispatcher2));

            dispatcher1.FirstName = "Bob";
            Provider.UpdateDispatcher(dispatcher1);
            dispatcherList = Provider.GetDispatchers();
            dispatcher1 = dispatcherList[0];
            Assert.IsFalse(dispatcher1.FirstName == "Eric");

            Provider.DeleteDispatcher(dispatcher1.DispatcherId);
            Provider.DeleteDispatcher(dispatcher2.DispatcherId);
        }

        [TestMethod]
        public void ChannelADispatcherReport_Test()
        {
            DateTime beginDate = DateTime.Now.AddMonths(-3);
            DateTime endDate = DateTime.Now;

            PrimaryIncidentDispatcherReport incident = new PrimaryIncidentDispatcherReport();
            incident = Provider.GetPrimaryIncidentDispatcherReport(beginDate, endDate);
        }

        [TestMethod]
        public void TertiaryReceptor_Tests()
        {
            int correct = 5;
            int minor = 3;
            int incorrect = 2;

            decimal score = Provider.TertiaryReceptor(correct, minor, incorrect, 25, 10, 0, false);
            Assert.IsTrue(score == 0.62m);
        }

        [TestMethod]
        public void TertiaryReceptor_NA_Tests()
        {
            int Yes = 5;
            int No = 5;
            int Na = 14;

            decimal score = Provider.TertiaryReceptor(Yes, No, Na, 5, 0, 0, true);
            Assert.IsTrue(score == 0.5m);
        }

        [TestMethod]
        public void Login_Valid()
        {
            string username = "PirasDev";
            string password = "PirasDev";

            Assert.IsTrue(Provider.Login(username, password));
        }
    }
}
