using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mayhem.DTO;
using Mayhem.WebUI.Models;
using Mayhem.Logic;

namespace Mayhem.WebUI.Controllers
{
    public static class DropDownUtility
    {
        public static SelectList GetEvaluatorDropDown()
        {

            List<DropDownModelString> list = new List<DropDownModelString>();
            List<Dispatcher> dispatchers = Provider.GetDispatchers();
            string format = "{0}, {1}";

            foreach (Dispatcher dispatcher in dispatchers)
            {
                DropDownModelString model = new DropDownModelString();

                model.Text = string.Format(format, dispatcher.LastName, dispatcher.FirstName);
                model.Value = dispatcher.DispatcherId;

                list.Add(model);
            }

            return new SelectList(list, "Value", "Text");
        }

        public static SelectList GetShiftDropDown()
        {

            List<DropDownModelInt> list = new List<DropDownModelInt>();
            List<Shift> shifts = Provider.GetShifts();

            foreach (Shift shift in shifts)
            {
                DropDownModelInt model = new DropDownModelInt();

                model.Text = shift.ShiftName;
                model.Value = shift.ShiftId;

                list.Add(model);
            }

            return new SelectList(list, "Value", "Text");
        }

        public static SelectList GetCorrectMinorIncorrectDropDown()
        {

            List<DropDownModelString> list = new List<DropDownModelString>();
           
                DropDownModelString modelCorrect = new DropDownModelString();

                modelCorrect.Text = "Correct";
                modelCorrect.Value = "Correct";

                list.Add(modelCorrect);

                DropDownModelString modelMinor = new DropDownModelString();

                modelMinor.Text = "Minor";
                modelMinor.Value = "Minor";

                list.Add(modelMinor);

                DropDownModelString modelIncorrect = new DropDownModelString();

                modelIncorrect.Text = "Incorrect";
                modelIncorrect.Value = "Incorrect";

                list.Add(modelIncorrect);
           

            return new SelectList(list, "Value", "Text");
        }


    }
}