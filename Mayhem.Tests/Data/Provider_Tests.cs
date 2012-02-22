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
    }
}
