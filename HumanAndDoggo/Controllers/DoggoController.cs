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
    public class DoggoController : ApiController
    {
        public IHttpActionResult Get()
        {
            var service = new DoggoService();
            var doggo = service.GetDoggos();
            return Ok(doggo);
        }
        public IHttpActionResult GetById(int id)
        {
            var service = new DoggoService();
            var doggo = service.GetDoggoById(id);
            return Ok(doggo);
        }
        public IHttpActionResult Post(DoggoCreate doggo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new DoggoService();

            if (!service.Create(doggo))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(DoggoEdit doggo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new DoggoService();

            if (!service.UpdateDog(doggo))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = new DoggoService();

            if (!service.DeleteDog(id))
                return InternalServerError();

            return Ok();
        }
    }
}
