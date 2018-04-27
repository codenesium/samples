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
			IAirTransportModelValidator airTransportModelValidator)
			: base(logger, airTransportRepository, airTransportModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>f147f0778e499946bab1ef51202d24f3</Hash>
</Codenesium>*/