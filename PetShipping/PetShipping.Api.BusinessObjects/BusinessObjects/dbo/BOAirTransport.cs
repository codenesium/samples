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
			IApiAirTransportRequestModelValidator airTransportModelValidator,
			IBOLAirTransportMapper airTransportMapper)
			: base(logger, airTransportRepository, airTransportModelValidator, airTransportMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>6efda52648564fd1495227163ef75a18</Hash>
</Codenesium>*/