using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class ScrapReasonService : AbstractScrapReasonService, IScrapReasonService
	{
		public ScrapReasonService(
			ILogger<IScrapReasonRepository> logger,
			IScrapReasonRepository scrapReasonRepository,
			IApiScrapReasonRequestModelValidator scrapReasonModelValidator,
			IBOLScrapReasonMapper bolscrapReasonMapper,
			IDALScrapReasonMapper dalscrapReasonMapper,
			IBOLWorkOrderMapper bolWorkOrderMapper,
			IDALWorkOrderMapper dalWorkOrderMapper
			)
			: base(logger,
			       scrapReasonRepository,
			       scrapReasonModelValidator,
			       bolscrapReasonMapper,
			       dalscrapReasonMapper,
			       bolWorkOrderMapper,
			       dalWorkOrderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b4bc14159247af095ee1c5caf639357b</Hash>
</Codenesium>*/