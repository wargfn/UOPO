using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public IEnumerable<GroupCardsDTO> GetGroupCards()
        {
            var groupCards = _context.GroupCards.ToList().Select(Mapper.Map<GroupCards,GroupCardsDTO>);

            if (groupCards == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return groupCards;
        }

        // GET /API/GrouPCards/1
        public GroupCardsDTO GetGroupCards(int id)
        {
            var groupCard = _context.GroupCards.SingleOrDefault(C => C.Id == id);

            if (groupCard == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<GroupCards, GroupCardsDTO>(groupCard);
        }


        // Post /api/GroupCards
        [HttpPost]
        public GroupCardsDTO CreateGroupCards(GroupCardsDTO groupCardDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var groupCard = Mapper.Map<GroupCardsDTO, GroupCards>(groupCardDTO);
            _context.GroupCards.Add(groupCard);
            _context.SaveChanges();

            groupCardDTO.Id = groupCard.Id;

            return groupCardDTO;
        }

        // Post /API/GroupCards/1
        [HttpPut]
        public GroupCardsDTO UpdateGroupCard(int id, GroupCardsDTO groupCardDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var groupCardInDB = _context.GroupCards.SingleOrDefault(c => c.Id == id);

            if (groupCardInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(groupCardDTO, groupCardInDB);
          
            _context.SaveChanges();

            return groupCardDTO;
        }

        // DELETE /api/GroupCards/1
        [HttpDelete]
        public void DeleteGroupCard(int id)
        {
            var groupCardInDB = _context.GroupCards.SingleOrDefault(c => c.Id == id);

            if (groupCardInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.GroupCards.Remove(groupCardInDB);
            _context.SaveChanges();
        }
    }
}
