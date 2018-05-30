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
			IDALAirTransportMapper mapper,
			ILogger<AirTransportRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>890f15333ba7895be774678c1786b5bc</Hash>
</Codenesium>*/