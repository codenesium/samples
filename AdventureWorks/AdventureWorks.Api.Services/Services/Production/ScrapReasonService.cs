using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ScrapReasonService : AbstractScrapReasonService, IScrapReasonService
	{
		public ScrapReasonService(
			ILogger<IScrapReasonRepository> logger,
			IMediator mediator,
			IScrapReasonRepository scrapReasonRepository,
			IApiScrapReasonServerRequestModelValidator scrapReasonModelValidator,
			IBOLScrapReasonMapper bolScrapReasonMapper,
			IDALScrapReasonMapper dalScrapReasonMapper,
			IBOLWorkOrderMapper bolWorkOrderMapper,
			IDALWorkOrderMapper dalWorkOrderMapper)
			: base(logger,
			       mediator,
			       scrapReasonRepository,
			       scrapReasonModelValidator,
			       bolScrapReasonMapper,
			       dalScrapReasonMapper,
			       bolWorkOrderMapper,
			       dalWorkOrderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>884ccea65e314bda0d044d9962137efd</Hash>
</Codenesium>*/