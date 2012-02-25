using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mayhem.Logic;
using Mayhem.DTO;

namespace Mayhem.WebUI.Controllers
{
    public class ChannelController : Controller
    {
        //
        // GET: /Channel/

        public ActionResult Index()
        {
            return View(Provider.GetChannels());
        }

        public ViewResult Edit(int channelId)
        {
            return View(Provider.GetChannel(channelId));
        }

        [HttpPost]
        public ViewResult Edit(Channel channel)
        {
            Provider.UpdateChannel(channel);
            return View("Index", Provider.GetChannels());
        }

        public ViewResult Delete(int channelId)
        {
            Provider.DeleteChannel(channelId);
            return View("Index", Provider.GetChannels());
        }

       
        public ViewResult Create()
        {
            return View(new Channel());
        }

        [HttpPost]
        public ViewResult Create(Channel channel)
        {
            Provider.CreateChannel(channel.ChannelName);
            return View("Index", Provider.GetChannels());
        }
    }
}
