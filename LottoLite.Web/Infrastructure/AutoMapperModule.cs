using AutoMapper;
using LottoLite.Entities;
using LottoLite.Web.Models;
using Ninject;
using Ninject.Modules;
using System.Collections.Generic;

namespace LottoLite.Web.App_Start
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().ToMethod(RegisterAutoMapper).InSingletonScope();
        }

        private IMapper RegisterAutoMapper(Ninject.Activation.IContext context)
        {

            Mapper.Initialize(config =>
            {
                config.ConstructServicesUsing(type => context.Kernel.Get(type));
               
                // Set mappings
                config.CreateMap<LotteryDrawModel, LotteryDraw>();
                config.CreateMap<WinningNumbersModel, WinningNumbers>()
                    .ForMember(d => d.PrimaryWinningNumbers, opt => opt.MapFrom(s => new List<int> { s.PrimaryFirst }))
                    .ForMember(d => d.SecondaryWinningNumbers, opt => opt.MapFrom(s => new List<int> { s.SecondaryFirst }))
                    .AfterMap((s, d) => d.PrimaryWinningNumbers.Add(s.PrimarySecond))
                    .AfterMap((s, d) => d.PrimaryWinningNumbers.Add(s.PrimaryThird))
                    .AfterMap((s, d) => d.PrimaryWinningNumbers.Add(s.PrimaryFourth))
                    .AfterMap((s, d) => d.PrimaryWinningNumbers.Add(s.PrimaryFifth))
                    .AfterMap((s, d) => d.SecondaryWinningNumbers.Add(s.SecondarySecond))
                    ;
            });

            //Mapper.AssertConfigurationIsValid(); // for debug
            return Mapper.Instance;
        }
    }
}