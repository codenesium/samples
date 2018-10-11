using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class RateService : AbstractRateService, IRateService
	{
		public RateService(
			ILogger<IRateRepository> logger,
			IRateRepository rateRepository,
			IApiRateRequestModelValidator rateModelValidator,
			IBOLRateMapper bolrateMapper,
			IDALRateMapper dalrateMapper)
			: base(logger,
			       rateRepository,
			       rateModelValidator,
			       bolrateMapper,
			       dalrateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>0844a7e06ee27284ef7e8bf22d10d58c</Hash>
</Codenesium>*/