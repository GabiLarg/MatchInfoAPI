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


        [Route("categories")]
        [HttpGet]
        public ActionResult GetCategories( string categoryRequest)
        {
            try
            {
                var response = this.analyzer.GetCategories(categoryRequest);
                return Ok(response);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("sentiments")]
        [HttpGet]
        public ActionResult GetSentiments (string sentimentRequest)
        {
            try
            {
                var response = this.analyzer.GetSentiments(sentimentRequest);
                return Ok(response);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
