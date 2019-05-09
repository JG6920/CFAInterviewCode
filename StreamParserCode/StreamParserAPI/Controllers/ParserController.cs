using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StreamParser.Services;
using StreamParser.Models;
using System.Web.Http.Description;

namespace StreamParserAPI.Controllers
{
    [RoutePrefix("api/Parser")]
    public class ParserController : ApiController
    {
        IStreamParserService<IInput<string>, char> _streamParserService;
        IScoreService _scoreService;

        public ParserController(IStreamParserService<IInput<string>, char> streamParserService, IScoreService scoreService)
        {
            this._streamParserService = streamParserService;
            this._scoreService = scoreService;
        }

        [HttpPost]
        [Route("getScore")]
        [ResponseType(typeof(IResult<int>))]
        // POST: api/Parser/getScore
        public IHttpActionResult Post(Input value)
        {
            if (value == null||value._input==null) { return BadRequest(); }
            this._streamParserService.setInput(value);
            this._scoreService.setGroup(this._streamParserService.Parse());
            return Ok(this._scoreService.getResult());
        }

    }
}
