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
			IDALSpecialOfferMapper dalSpecialOfferMapper)
			: base(logger,
			       mediator,
			       specialOfferRepository,
			       specialOfferModelValidator,
			       dalSpecialOfferMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>524e67dd75ef2ef57fbe9bc8f1a306b3</Hash>
</Codenesium>*/