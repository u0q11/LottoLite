using AutoMapper;
using LottoLite.Entities;
using LottoLite.Interfaces.Services;
using LottoLite.Web.Models;
using LottoLite.Web.Validators;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LottoLite.Web.Controllers.API
{
    public class WinningNumbersController : ApiController
    {
        private IWinningNumbersService _winningNumbersService;
        private ILotteryDrawSearchService _searchSvc;
        private IMapper _mapper;

        public WinningNumbersController(IWinningNumbersService winningNumbersService, ILotteryDrawSearchService searchSvc, IMapper mapper)
        {
            _winningNumbersService = winningNumbersService;
            _searchSvc = searchSvc;
            _mapper = mapper;
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]WinningNumbersModel model)
        {
            // fetch draw (check exists)
            var draw = _searchSvc.GetDrawByName(model.DrawName);
            if (draw == null)
            {
                ModelState.AddModelError("error", string.Format("Draw '{0}' not found", model.DrawName));
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            
            var winningNumbers = Mapper.Map<WinningNumbers>(model);
            
            // validate numbers, provide feedback
            _winningNumbersService.ValidateWinningNumbers(draw, winningNumbers, ValidationFactory.CreateCollection())
                .Where(x => !x.IsValid).ToList().ForEach((error) =>
                {
                    ModelState.AddModelError("error", string.Format(error.Message));
                });

            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            // all ok, save
            _winningNumbersService.SetWinningNumbers(draw, Mapper.Map<WinningNumbers>(model));

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}