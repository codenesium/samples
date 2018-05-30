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
	public class AirlineRepository: AbstractAirlineRepository, IAirlineRepository
	{
		public AirlineRepository(
			IDALAirlineMapper mapper,
			ILogger<AirlineRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>25ad6977b96feec0066c1cd7543759c2</Hash>
</Codenesium>*/