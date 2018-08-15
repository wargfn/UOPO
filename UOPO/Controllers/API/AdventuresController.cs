using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using UOPO.Models;
using UOPO.DTOs;
using AutoMapper;

namespace UOPO.Controllers.API
{
    public class AdventuresController : ApiController
    {
        private ApplicationDbContext _context;

        public AdventuresController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /API/Adventures
        public IHttpActionResult GetAdventures(string query = null)
        {
            var adventuresQuery = _context.Adventures.Include(c => c.GetEncounterList);

            if (!String.IsNullOrWhiteSpace(query))
                adventuresQuery = adventuresQuery.Where(c => c.Name.Contains(query));

            //if (adventures == null)
            //     throw new HttpResponseException(HttpStatusCode.NotFound);
            var adventuresDTO = adventuresQuery.ToList().Select(Mapper.Map<AdventuresModel, AdventuresDTO>);

            return Ok(adventuresDTO);
        }

        // GET /API/Adventures/1
        public AdventuresDTO GetAdventures(int id)
        {
            var adventure = _context.Adventures.Include(c => c.GetEncounterList).SingleOrDefault(C => C.Id == id);

            if (adventure == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<AdventuresModel, AdventuresDTO>(adventure);
        }


        // Post /api/Adventures
        [HttpPost]
        public IHttpActionResult CreateAdventures(AdventuresDTO adventuresDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var adventures = Mapper.Map<AdventuresDTO, AdventuresModel>(adventuresDTO);
            _context.Adventures.Add(adventures);
            _context.SaveChanges();

            adventuresDTO.Id = adventures.Id;

            return Created(new Uri(Request.RequestUri + "/" + adventures.Id), adventuresDTO);
        }

        // Post /API/Adventures/1
        [HttpPut]
        public IHttpActionResult UpdateAdventure(int id, AdventuresDTO adventureDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var adventureInDB = _context.Adventures.SingleOrDefault(c => c.Id == id);

            if (adventureInDB == null)
                return NotFound();

            Mapper.Map(adventureDTO, adventureInDB);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/Adventures/1
        [HttpDelete]
        public IHttpActionResult DeleteAdventure(int id)
        {
            var adventureInDB = _context.Adventures.SingleOrDefault(c => c.Id == id);

            if (adventureInDB == null)
                return NotFound();

            _context.Adventures.Remove(adventureInDB);
            _context.SaveChanges();

            return Ok();
        }
        
    }
}
