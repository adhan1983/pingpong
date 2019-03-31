using PingPong.Application.DTOs;
using PingPong.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PingPong.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PlayersController : BaseController
    {
        private readonly IPlayerAppService _playerAppService;
        public PlayersController()
        {
            _playerAppService = _container.GetInstance<IPlayerAppService>();
        }
        // GET: api/Players
        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<PlayerDTO> players = _playerAppService.GetPlayers();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, players);

            return response;
        }

        // GET: api/Players/5
        public HttpResponseMessage Get(int id)
        {
            PlayerDTO player = _playerAppService.GetPlayer(id);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, player);

            return response;
        }

        // POST: api/Players
        [HttpPost]
        public HttpResponseMessage Post([FromBody]PlayerDTO player)
        {
            bool status = _playerAppService.InsertPlayer(player);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, status);

            return response;
        }

        // PUT: api/Players/5
        [HttpPut]
        public HttpResponseMessage Put([FromBody]PlayerDTO player)
        {
            bool status = _playerAppService.UpDatePlayer(player);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, status);

            return response;
        }

        // DELETE: api/Players/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            bool status = _playerAppService.DeletePlayer(id);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, status);

            return response;
        }
        
    }
}
