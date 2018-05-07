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
			IObjectMapper mapper,
			ILogger<AirlineRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>91f45952b2a97df3e2f5d72ecfd839a2</Hash>
</Codenesium>*/