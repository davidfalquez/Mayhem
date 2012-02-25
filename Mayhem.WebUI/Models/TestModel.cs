using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mayhem.WebUI.Models
{
    public class TestModel
    {
        public string MyValue { get; set; }
        public SelectList MyDropDown { get; set; }

    }

    public class TestModelSelectItem
    {
        public string SelectValue { get; set; }
        public string SelectName { get; set; }

    }

    public static class TestModelManager
    {
        public static List<TestModel> GetTestModels()
        {
            List<TestModel> models = new List<TestModel>();
            TestModel m1 = new TestModel();
            m1.MyValue = "M1";
            m1.MyDropDown = GetDropDown();

            TestModel m2 = new TestModel();
            m2.MyValue = "M2";
            m2.MyDropDown = GetDropDown();

            models.Add(m1);
            models.Add(m2);

            return models;
        }

        private static SelectList GetDropDown()
        {
            List<TestModelSelectItem> list = new List<TestModelSelectItem>();
            TestModelSelectItem s1 = new TestModelSelectItem();
            s1.SelectName = "Option 1";
            s1.SelectValue = "Value 1";

            TestModelSelectItem s2 = new TestModelSelectItem();
            s2.SelectName = "Option 2";
            s2.SelectValue = "Value 2";

            list.Add(s1);
            list.Add(s2);

            return new SelectList(list, "SelectValue", "SelectName");
        }
        
    }
}