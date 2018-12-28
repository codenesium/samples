using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class SpecialOfferService : AbstractSpecialOfferService, ISpecialOfferService
	{
		public SpecialOfferService(
			ILogger<ISpecialOfferRepository> logger,
			IMediator mediator,
			ISpecialOfferRepository specialOfferRepository,
			IApiSpecialOfferServerRequestModelValidator specialOfferModelValidator,
			IBOLSpecialOfferMapper bolSpecialOfferMapper,
			IDALSpecialOfferMapper dalSpecialOfferMapper)
			: base(logger,
			       mediator,
			       specialOfferRepository,
			       specialOfferModelValidator,
			       bolSpecialOfferMapper,
			       dalSpecialOfferMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>58ad8f955de684c379634b9c83059f2b</Hash>
</Codenesium>*/