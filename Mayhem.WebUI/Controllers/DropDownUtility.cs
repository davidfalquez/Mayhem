﻿using System;
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
        public static SelectList GetChannelDropDown()
        {
            List<DropDownModelInt> list = new List<DropDownModelInt>();
            List<Channel> channels = Provider.GetChannels();
            
            foreach (Channel channel in channels)
            {
                //TODO: Make Channel A a string constant
                if (channel.ChannelName != "Channel A")
                {
                    DropDownModelInt model = new DropDownModelInt();

                    model.Text = channel.ChannelName;
                    model.Value = channel.ChannelId;

                    list.Add(model);
                }
            }

            return new SelectList(list, "Value", "Text");
        }

        public static SelectList GetRoleTypeDropDown()
        {
            List<DropDownModelInt> list = new List<DropDownModelInt>();
            List<Role> roles = Provider.GetRoles();

            foreach (Role role in roles)
            {
                if (role.RoleTypeDescription != "Developer")
                {
                    DropDownModelInt model = new DropDownModelInt();

                    model.Text = role.RoleTypeDescription;
                    model.Value = role.RoleTypeId;

                    list.Add(model);
                }
            }

            return new SelectList(list, "Value", "Text");
        }

        public static SelectList GetDispatcherDropDown()
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

        public static SelectList GetYesNoNADropDown()
        {

            List<DropDownModelString> list = new List<DropDownModelString>();

            DropDownModelString modelCorrect = new DropDownModelString();

            modelCorrect.Text = "Yes";
            modelCorrect.Value = "Yes";

            list.Add(modelCorrect);

            DropDownModelString modelMinor = new DropDownModelString();

            modelMinor.Text = "No";
            modelMinor.Value = "No";

            list.Add(modelMinor);

            DropDownModelString modelIncorrect = new DropDownModelString();

            modelIncorrect.Text = "NA";
            modelIncorrect.Value = "NA";

            list.Add(modelIncorrect);


            return new SelectList(list, "Value", "Text");
        }


    }
}