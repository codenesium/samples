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
	public class BOAirline: AbstractBOAirline, IBOAirline
	{
		public BOAirline(
			ILogger<AirlineRepository> logger,
			IAirlineRepository airlineRepository,
			IApiAirlineRequestModelValidator airlineModelValidator,
			IBOLAirlineMapper airlineMapper)
			: base(logger, airlineRepository, airlineModelValidator, airlineMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>24b42f62d12bc8ee81c2ea2eff8cb071</Hash>
</Codenesium>*/