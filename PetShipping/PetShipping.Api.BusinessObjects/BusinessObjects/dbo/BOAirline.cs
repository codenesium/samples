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
			IApiAirlineModelValidator airlineModelValidator)
			: base(logger, airlineRepository, airlineModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>9a7f56f2eedb56e7abd2d6813067312b</Hash>
</Codenesium>*/