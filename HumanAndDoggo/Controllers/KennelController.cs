using HumanAndDoggo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HumanAndDoggo.Model;

namespace HumanAndDoggo.Controllers
{
    public class KennelController : ApiController
    {
        public IHttpActionResult Get()
        {
            var service = new KennelService();
            var kennel = service.GetKennels();
            return Ok(kennel);
        }
        public IHttpActionResult GetById(int id)
        {
            var service = new KennelService();
            var kennel = service.GetKennelByNumber(id);
            return Ok(kennel);
        }
        public IHttpActionResult Post(KennelCreate kennel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new KennelService();

            if (!service.CreateKennel(kennel))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(KennelEdit kennel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new KennelService();

            if (!service.UpdateKennel(kennel))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = new KennelService();

            if (!service.KillKennel(id))
                return InternalServerError();

            return Ok();
        }
    }
}
