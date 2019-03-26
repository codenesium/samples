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
			IDALScrapReasonMapper dalScrapReasonMapper,
			IDALWorkOrderMapper dalWorkOrderMapper)
			: base(logger,
			       mediator,
			       scrapReasonRepository,
			       scrapReasonModelValidator,
			       dalScrapReasonMapper,
			       dalWorkOrderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a48f51b6a9fd0076587cec07b15995b3</Hash>
</Codenesium>*/