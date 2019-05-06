using HumanAndDoggo.Model;
using HumanAndDoggo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HumanAndDoggo.Controllers
{
    public class HumanController : ApiController
    {
        public IHttpActionResult Get()
        {
            var service = new HumanService();
            var human = service.GetHuman();
            return Ok(human);
        }
        public IHttpActionResult GetHumanById(int humanID)
        {
            var service = new HumanService();
            var human = service.GetHumanById(humanID);
            return Ok(human);
        }
        public IHttpActionResult Post(HumanCreate human)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = new HumanService();
            if (!service.Create(human))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Put(HumanEdit human)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = new HumanService();
            if (!service.UpdateHuman(human))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = new HumanService();
            if (!service.DeleteHuman(id))
                return InternalServerError();
            return Ok();
        }
    }
}
