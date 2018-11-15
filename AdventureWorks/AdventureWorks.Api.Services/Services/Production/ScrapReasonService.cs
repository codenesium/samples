using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ScrapReasonService : AbstractScrapReasonService, IScrapReasonService
	{
		public ScrapReasonService(
			ILogger<IScrapReasonRepository> logger,
			IScrapReasonRepository scrapReasonRepository,
			IApiScrapReasonServerRequestModelValidator scrapReasonModelValidator,
			IBOLScrapReasonMapper bolScrapReasonMapper,
			IDALScrapReasonMapper dalScrapReasonMapper,
			IBOLWorkOrderMapper bolWorkOrderMapper,
			IDALWorkOrderMapper dalWorkOrderMapper)
			: base(logger,
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
    <Hash>73ad0848a17918b14011f5f5cdff0279</Hash>
</Codenesium>*/