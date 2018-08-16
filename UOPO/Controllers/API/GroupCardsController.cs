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
    public class GroupCardsController : ApiController
    {
        private ApplicationDbContext _context;

        public GroupCardsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /API/GroupCards
        public IHttpActionResult GetGroupCards(string query = null)
        {
            var groupCardsQuery = _context.GroupCards;

           //if (!String.IsNullOrWhiteSpace(query))
           //     groupCardsQuery = groupCardsQuery.Where(c => c.Name.Contains(query));

            var groupCardsDTO = groupCardsQuery.ToList().Select(Mapper.Map<GroupCards,GroupCardsDTO>);

            return Ok(groupCardsDTO);
        }

        // GET /API/GrouPCards/1
        public IHttpActionResult GetGroupCards(int id)
        {
            var groupCard = _context.GroupCards.SingleOrDefault(C => C.Id == id);

            if (groupCard == null)
                return NotFound();

            return Ok(Mapper.Map<GroupCards, GroupCardsDTO>(groupCard));
        }


        // Post /api/GroupCards
        [HttpPost]
        public IHttpActionResult CreateGroupCards(GroupCardsDTO groupCardDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var groupCard = Mapper.Map<GroupCardsDTO, GroupCards>(groupCardDTO);
            _context.GroupCards.Add(groupCard);
            _context.SaveChanges();

            groupCardDTO.Id = groupCard.Id;

            return Created(new Uri(Request.RequestUri + "/" + groupCard.Id), groupCardDTO);
        }

        // Post /API/GroupCards/1
        [HttpPut]
        public IHttpActionResult UpdateGroupCard(int id, GroupCardsDTO groupCardDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var groupCardInDB = _context.GroupCards.SingleOrDefault(c => c.Id == id);

            if (groupCardInDB == null)
                return NotFound();

            Mapper.Map(groupCardDTO, groupCardInDB);
          
            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/GroupCards/1
        [HttpDelete]
        public IHttpActionResult DeleteGroupCard(int id)
        {
            var groupCardInDB = _context.GroupCards.SingleOrDefault(c => c.Id == id);

            if (groupCardInDB == null)
                return NotFound();

            _context.GroupCards.Remove(groupCardInDB);
            _context.SaveChanges();

            return Ok();
        }
    }
}
