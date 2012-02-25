using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mayhem.DTO;
using System.Data;

namespace Mayhem.Logic
{
    public static class Provider
    {
        private static string _InvalidMessage = "{0} cannot be null.";
        private static string _InvalidIdMessage = "{0} cannot be null, empty, or 0.";

        public static void CreateChannel(string channelName)
        {
            if (channelName == null)
            {
                throw new Exception(string.Format(_InvalidMessage, "Channel"));
            }
            Data.Provider.Channel_Insert(channelName);
        }

        public static void UpdateChannel(Channel channel)
        {
            if (channel == null)
            {
                throw new Exception(string.Format(_InvalidMessage, "Channel"));
            }
            Data.Provider.Channel_Update(channel);
        }

        public static Channel GetChannel(int channelId)
        {
            Channel returnValue = new Channel();
            DataSet channelDataSet = Data.Provider.Channel_SelectById(channelId);

            returnValue.ChannelId = int.Parse(channelDataSet.Tables[0].Rows[0]["ChannelId"].ToString());
            returnValue.ChannelName = channelDataSet.Tables[0].Rows[0]["ChannelName"].ToString();

            return returnValue;
        }

        public static List<Channel> GetChannels()
        {
            List<Channel> returnValue = new List<Channel>();
            DataSet channelDataSet = Data.Provider.Channel_SelectAll();

            foreach (DataRow row in channelDataSet.Tables[0].Rows)
            {
                Channel channel = new Channel();
                channel.ChannelId = int.Parse(row["ChannelId"].ToString());
                channel.ChannelName = row["ChannelName"].ToString();
                returnValue.Add(channel);
            }
            return returnValue;
        }

        public static void DeleteChannel(int channelId)
        {
            if (channelId <= 0)
            {
                throw new Exception(string.Format(_InvalidIdMessage, "Channel"));
            }
            Data.Provider.Channel_Delete(channelId);
        }
        
        public static void CreateDispatcher(Dispatcher dispatcher)       
        {
            if (dispatcher == null)
            {
                throw new Exception(string.Format(_InvalidMessage, "Dispatcher"));
            }         
            if (dispatcher.DispatcherId == null)
            {
                throw new Exception(string.Format(_InvalidIdMessage, "DispatcherId"));
            }            
            Data.Provider.Dispatcher_Insert(dispatcher);
        }

        public static void UpdateDispatcher(Dispatcher dispatcher)
        {
            if (dispatcher == null)
            {
                throw new Exception(_InvalidMessage);
            }
            if (dispatcher.DispatcherId == null)
            {
                throw new Exception(_InvalidIdMessage);
            }
            Data.Provider.Dispatcher_Update(dispatcher);
        }

        public static Dispatcher GetDispatcher(string dispatcherId)
        {
            Dispatcher returnValue = new Dispatcher();
            DataSet dispatcherDataSet = Data.Provider.Dispatcher_SelectById(dispatcherId);

            returnValue.DispatcherId = dispatcherDataSet.Tables[0].Rows[0]["DispatcherId"].ToString();
            returnValue.FirstName = dispatcherDataSet.Tables[0].Rows[0]["FirstName"].ToString();
            returnValue.LastName = dispatcherDataSet.Tables[0].Rows[0]["LastName"].ToString();
            returnValue.RoleTypeId = int.Parse(dispatcherDataSet.Tables[0].Rows[0]["RoleTypeId"].ToString());
            return returnValue;
        }

        public static List<Dispatcher> GetDispatchers()
        {
            List<Dispatcher> returnValue = new List<Dispatcher>();
            DataSet dispatcherDataSet = Data.Provider.Dispatcher_SelectAll();
            
            foreach (DataRow row in dispatcherDataSet.Tables[0].Rows)
            {
                Dispatcher dispatcher = new Dispatcher();
                dispatcher.DispatcherId = row["DispatcherId"].ToString();
                dispatcher.FirstName = row["FirstName"].ToString();
                dispatcher.LastName = row["LastName"].ToString();
                dispatcher.RoleTypeId = int.Parse(row["RoleTypeId"].ToString());
                returnValue.Add(dispatcher);
            }
            return returnValue;
        }

        public static void DeleteDispatcher(string dispatcherId)
        {
            if (dispatcherId == null)
            {
                throw new Exception(_InvalidIdMessage);
            }
            Data.Provider.Dispatcher_Delete(dispatcherId);
        }
    }
}
