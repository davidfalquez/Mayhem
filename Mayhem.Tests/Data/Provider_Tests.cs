using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using Mayhem.Data;
using Mayhem.DTO;


namespace Mayhem.Tests.Data
{
    [TestClass]
    public class Provider_Tests
    {
        [TestMethod]
        public void Channel_SelectAll()
        {
            bool foundChannelB = false;
            string channelName = "Channel B";
            Provider.Channel_Insert(channelName);

            DataSet table1 = null;
            table1 = Provider.Channel_SelectAll();

            foreach (DataRow row in table1.Tables[0].Rows)
            {
                if (row["ChannelName"].ToString() == "Channel B")
                {
                    foundChannelB = true;
                    int channelId = int.Parse(row["ChannelId"].ToString());
                    Provider.Channel_Delete(channelId);
                }              
            }
            Assert.IsTrue(foundChannelB == true);

            table1 = Provider.Channel_SelectAll();
            foundChannelB = false;
            foreach (DataRow row in table1.Tables[0].Rows)
            {
                if (row["ChannelName"].ToString() == "Channel B")
                {
                    foundChannelB = true;
                    int channelId = int.Parse(row["ChannelId"].ToString());
                    Provider.Channel_Delete(channelId);
                }
            }
            Assert.IsTrue(foundChannelB == false);

        }

        [TestMethod]
        public void RoleType_SelectAll()
        {
            DataSet value = new DataSet();
            value = Provider.RoleType_SelectAll();
            Assert.IsTrue(value.Tables[0].Rows[0]["RoleDescription"].ToString() == "Administrator");
        }

        [TestMethod]
        public void Dispatcher_SelectById_Tests()
        {
            //Insert a new row
            Dispatcher dispatcher1 = new Dispatcher();
            dispatcher1.DispatcherId = "1234www";
            dispatcher1.FirstName = "Eric";
            dispatcher1.LastName = "Fayad";
            dispatcher1.RoleTypeId = 1;
            Provider.Dispatcher_Insert(dispatcher1);

            DataSet table1 = Provider.Dispatcher_SelectById(dispatcher1.DispatcherId);
            Provider.Dispatcher_Delete(dispatcher1.DispatcherId);
            Assert.IsTrue(table1.Tables[0].Rows[0]["DispatcherId"].ToString() == "1234www");
            Assert.IsTrue(table1.Tables[0].Rows[0]["FirstName"].ToString() == "Eric");
            Assert.IsTrue(table1.Tables[0].Rows[0]["LastName"].ToString() == "Fayad");
            Assert.IsTrue(table1.Tables[0].Rows[0]["RoleTypeId"].ToString() == "1");
            //Insert another row
            //Select all
            //Loop through each and make sure all the fields are what they should be
            //Update one
            //Select that one by ID and make sure all of the fields are what they should be
            //Clean up by deleting both of the guys
        }

        [TestMethod]
        public void Dispatcher_SelectAll_Tests()
        {
            Dispatcher dispatcher1 = new Dispatcher();
            dispatcher1.DispatcherId = "1234www";
            dispatcher1.FirstName = "Eric";
            dispatcher1.LastName = "Fayad";
            dispatcher1.RoleTypeId = 1;
            Provider.Dispatcher_Insert(dispatcher1);

            Dispatcher dispatcher2 = new Dispatcher();
            dispatcher2.DispatcherId = "5678www";
            dispatcher2.FirstName = "Christian";
            dispatcher2.LastName = "Maggiora";
            dispatcher2.RoleTypeId = 2;
            Provider.Dispatcher_Insert(dispatcher2);

            DataSet table1 = Provider.Dispatcher_SelectAll();
            Assert.IsTrue(table1.Tables[0].Rows[0]["DispatcherId"].ToString() == "1234www");
            Assert.IsTrue(table1.Tables[0].Rows[0]["FirstName"].ToString() == "Eric");
            Assert.IsTrue(table1.Tables[0].Rows[0]["LastName"].ToString() == "Fayad");
            Assert.IsTrue(table1.Tables[0].Rows[0]["RoleTypeId"].ToString() == "1");
            Assert.IsTrue(table1.Tables[0].Rows[1]["DispatcherId"].ToString() == "5678www");
            Assert.IsTrue(table1.Tables[0].Rows[1]["FirstName"].ToString() == "Christian");
            Assert.IsTrue(table1.Tables[0].Rows[1]["LastName"].ToString() == "Maggiora");
            Assert.IsTrue(table1.Tables[0].Rows[1]["RoleTypeId"].ToString() == "2");

            Provider.Dispatcher_Delete(dispatcher1.DispatcherId);
            Provider.Dispatcher_Delete(dispatcher2.DispatcherId);
        }
      
        [TestMethod]
        public void Dispatcher_Update_Tests()
        {
            Dispatcher dispatcher1 = new Dispatcher();
            dispatcher1.DispatcherId = "1234www";
            dispatcher1.FirstName = "Eric";
            dispatcher1.LastName = "Fayad";
            dispatcher1.RoleTypeId = 1;
            Provider.Dispatcher_Insert(dispatcher1);

            //selectbyid into a dataset and make sure firstname is Eric
            DataSet table1 = Provider.Dispatcher_SelectById(dispatcher1.DispatcherId);
            Assert.IsTrue(table1.Tables[0].Rows[0]["FirstName"].ToString() == "Eric");

            //selectbyid into the same dataset (not a new one) and make sure firstname is Bob
            dispatcher1.FirstName = "Bob";
            Provider.Dispatcher_Update(dispatcher1);
            table1 = Provider.Dispatcher_SelectById(dispatcher1.DispatcherId);
            Assert.IsTrue(table1.Tables[0].Rows[0]["FirstName"].ToString() == "Bob");

            //Delete dispatcher 1234www
            Provider.Dispatcher_Delete(dispatcher1.DispatcherId);
            table1 = Provider.Dispatcher_SelectById(dispatcher1.DispatcherId);
            Assert.IsTrue(table1.Tables[0].Rows.Count == 0);            
        }

        [TestMethod]
        public void Shift_SelectAll()
        {
            Shift shift1 = new Shift();
            shift1.ShiftName = "Shift B";
            shift1.ShiftAbbreviation = "ShB";
            Provider.Shift_Insert(shift1);

            Shift shift2 = new Shift();
            shift2.ShiftName = "Shift C";
            shift2.ShiftAbbreviation = "Night";
            Provider.Shift_Insert(shift2);

            DataSet table1 = Provider.Shift_SelectAll();
            Assert.IsTrue(table1.Tables[0].Rows[0]["ShiftName"].ToString() == "Shift B");
            Assert.IsTrue(table1.Tables[0].Rows[0]["ShiftAbbreviation"].ToString() == "ShB");
            Assert.IsTrue(table1.Tables[0].Rows[1]["ShiftName"].ToString() == "Shift C");
            Assert.IsTrue(table1.Tables[0].Rows[1]["ShiftAbbreviation"].ToString() == "Night");

            Provider.Shift_Delete(shift1.ShiftId);
            Provider.Shift_Delete(shift2.ShiftId);
        }

        [TestMethod]
        public void Shift_Update_Tests()
        {
            Shift shift1 = new Shift();
            shift1.ShiftName = "Shift B";
            shift1.ShiftAbbreviation = "ShB";
            Provider.Shift_Insert(shift1);

            Shift shift2 = new Shift();
            shift2.ShiftName = "Shift C";
            shift2.ShiftAbbreviation = "Night";
            Provider.Shift_Insert(shift2);

            DataSet table1 = Provider.Shift_SelectAll();
            Assert.IsTrue(table1.Tables[0].Rows.Count > 2);

            Shift updateShift = new Shift();
            updateShift.ShiftId = int.Parse(table1.Tables[0].Rows[0]["ShiftId"].ToString());
            updateShift.ShiftName = table1.Tables[0].Rows[0]["ShiftName"].ToString();
            updateShift.ShiftAbbreviation = table1.Tables[0].Rows[0]["ShiftAbbreviation"].ToString();
            
            updateShift.ShiftName += " Changed";
            string shiftName = updateShift.ShiftName;

            Provider.Shift_Update(updateShift);

            table1 = Provider.Shift_SelectAll();

            updateShift = new Shift();
            updateShift.ShiftId = int.Parse(table1.Tables[0].Rows[0]["ShiftId"].ToString());
            updateShift.ShiftName = table1.Tables[0].Rows[0]["ShiftName"].ToString();
            updateShift.ShiftAbbreviation = table1.Tables[0].Rows[0]["ShiftAbbreviation"].ToString();

            Assert.IsTrue(updateShift.ShiftName == shiftName);

            Provider.Shift_Delete(shift1.ShiftId);
            Provider.Shift_Delete(shift2.ShiftId);
        }
    }
}
