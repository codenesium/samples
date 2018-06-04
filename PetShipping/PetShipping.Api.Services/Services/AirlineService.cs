using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public class AirlineService: AbstractAirlineService, IAirlineService
	{
		public AirlineService(
			ILogger<AirlineRepository> logger,
			IAirlineRepository airlineRepository,
			IApiAirlineRequestModelValidator airlineModelValidator,
			IBOLAirlineMapper BOLairlineMapper,
			IDALAirlineMapper DALairlineMapper)
			: base(logger, airlineRepository,
			       airlineModelValidator,
			       BOLairlineMapper,
			       DALairlineMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>22937a37dcea8ee5137ac5bf024aece2</Hash>
</Codenesium>*/