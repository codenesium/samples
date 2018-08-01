using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
	public partial class AirTransportRepository : AbstractAirTransportRepository, IAirTransportRepository
	{
		public AirTransportRepository(
			ILogger<AirTransportRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9dd163847873f92a5dc487d3199f078b</Hash>
</Codenesium>*/