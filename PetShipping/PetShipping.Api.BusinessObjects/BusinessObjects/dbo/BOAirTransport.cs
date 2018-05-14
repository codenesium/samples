using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class BOAirTransport: AbstractBOAirTransport, IBOAirTransport
	{
		public BOAirTransport(
			ILogger<AirTransportRepository> logger,
			IAirTransportRepository airTransportRepository,
			IApiAirTransportModelValidator airTransportModelValidator)
			: base(logger, airTransportRepository, airTransportModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>d7b7b8f29bcb158cd28cbcad80907f8f</Hash>
</Codenesium>*/