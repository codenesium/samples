using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public class AirTransportRepository: AbstractAirTransportRepository, IAirTransportRepository
	{
		public AirTransportRepository(
			IObjectMapper mapper,
			ILogger<AirTransportRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>47d6efd4ad55183785d649ef7d349a02</Hash>
</Codenesium>*/