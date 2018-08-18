using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial class RateService : AbstractRateService, IRateService
	{
		public RateService(
			ILogger<IRateRepository> logger,
			IRateRepository rateRepository,
			IApiRateRequestModelValidator rateModelValidator,
			IBOLRateMapper bolrateMapper,
			IDALRateMapper dalrateMapper
			)
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
    <Hash>fc1867d6e6121e571050c4bf59642810</Hash>
</Codenesium>*/