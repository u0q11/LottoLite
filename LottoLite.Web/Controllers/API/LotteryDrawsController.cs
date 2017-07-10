using AutoMapper;
using LottoLite.Entities;
using LottoLite.Interfaces.Entities;
using LottoLite.Interfaces.Services;
using LottoLite.Web.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LottoLite.Web.Controllers.API
{
    public class LotteryDrawsController : ApiController
    {
        private ILotteryDrawCreationService _creationSvc;
        private ILotteryDrawSearchService _searchSvc;
        private IMapper _mapper;

        public LotteryDrawsController(ILotteryDrawCreationService creationSvc, ILotteryDrawSearchService searchSvc, IMapper mapper)
        {
            _creationSvc = creationSvc;
            _searchSvc = searchSvc;
            _mapper = mapper;
        }

        // GET api/<controller>
        public HttpResponseMessage Get([FromUri]LotteryDrawSearchModel searchOptions)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            
            IList<ILotteryDraw> draws = _searchSvc.GetDrawsByDate(searchOptions.Date);

            return Request.CreateResponse(HttpStatusCode.OK, draws, "application/json");
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]LotteryDrawModel model)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            ILotteryDraw draw = _mapper.Map<LotteryDraw>(model);
            _creationSvc.AddDraw(draw);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}