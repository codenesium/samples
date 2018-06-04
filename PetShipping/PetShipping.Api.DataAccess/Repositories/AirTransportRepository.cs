using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
	public class AirTransportRepository: AbstractAirTransportRepository, IAirTransportRepository
	{
		public AirTransportRepository(
			ILogger<AirTransportRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>3e9737951db5707fdf1130395752fed6</Hash>
</Codenesium>*/