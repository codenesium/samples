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
			IAirlineModelValidator airlineModelValidator)
			: base(logger, airlineRepository, airlineModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>3a2a4a330e1befdeaa3dd88d49cb6dba</Hash>
</Codenesium>*/