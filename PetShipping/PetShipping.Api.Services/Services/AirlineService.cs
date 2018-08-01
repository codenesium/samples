using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class AirlineService : AbstractAirlineService, IAirlineService
	{
		public AirlineService(
			ILogger<IAirlineRepository> logger,
			IAirlineRepository airlineRepository,
			IApiAirlineRequestModelValidator airlineModelValidator,
			IBOLAirlineMapper bolairlineMapper,
			IDALAirlineMapper dalairlineMapper
			)
			: base(logger,
			       airlineRepository,
			       airlineModelValidator,
			       bolairlineMapper,
			       dalairlineMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b765d111960237978bf3a5f39d887aad</Hash>
</Codenesium>*/