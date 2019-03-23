using System;
using System.Collections.Generic;
using MatchInfo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MatchInfo.Controllers
{
    [Route("api/matchData")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private IAnalyzer analyzer;
        public MatchController(IAnalyzer analyzer)
        {
            this.analyzer = analyzer ?? throw new ArgumentNullException(nameof(analyzer));
        }

        [HttpGet]
        public ActionResult HealthCheck()
        {
            return Ok("Up");
        }

        [Route("categories")]
        [HttpGet]
        public ActionResult GetCategories([FromQuery] string request)
        {
            try
            {
                var response = this.analyzer.GetCategories(request);
                return Ok(response);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("sentiments")]
        [HttpGet]
        public ActionResult GetSentiments ([FromQuery]string request)
        {
            try
            {
                var response = this.analyzer.GetSentiments(request);
                return Ok(response);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
