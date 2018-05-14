using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOLocation: AbstractBOLocation, IBOLocation
	{
		public BOLocation(
			ILogger<LocationRepository> logger,
			ILocationRepository locationRepository,
			IApiLocationModelValidator locationModelValidator)
			: base(logger, locationRepository, locationModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>b6b5a84b9b5950983d8cde533770e796</Hash>
</Codenesium>*/