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

    public class SkillLevelsController : BaseController
    {
        private readonly ISkillLevelAppService _skillLevelAppService;
        public SkillLevelsController()
        {
            _skillLevelAppService = _container.GetInstance<ISkillLevelAppService>();
        }


        // GET: api/SkillLevels
        [HttpGet]
        public HttpResponseMessage Get()
        {
            
            var skillLevels = _skillLevelAppService.GetSkillLevels();
            
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, skillLevels);

            return response;
        }
    }
}
