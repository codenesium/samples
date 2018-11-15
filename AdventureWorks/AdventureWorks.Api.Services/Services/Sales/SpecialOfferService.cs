using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class SpecialOfferService : AbstractSpecialOfferService, ISpecialOfferService
	{
		public SpecialOfferService(
			ILogger<ISpecialOfferRepository> logger,
			ISpecialOfferRepository specialOfferRepository,
			IApiSpecialOfferServerRequestModelValidator specialOfferModelValidator,
			IBOLSpecialOfferMapper bolSpecialOfferMapper,
			IDALSpecialOfferMapper dalSpecialOfferMapper)
			: base(logger,
			       specialOfferRepository,
			       specialOfferModelValidator,
			       bolSpecialOfferMapper,
			       dalSpecialOfferMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9976368e6eed0ec170a6cc567f508b44</Hash>
</Codenesium>*/