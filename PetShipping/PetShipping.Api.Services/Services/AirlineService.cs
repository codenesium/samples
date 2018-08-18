using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>8f90b99977ae987ea80a05625713660d</Hash>
</Codenesium>*/