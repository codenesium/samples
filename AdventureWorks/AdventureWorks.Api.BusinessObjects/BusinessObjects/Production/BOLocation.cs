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
			ILocationModelValidator locationModelValidator)
			: base(logger, locationRepository, locationModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>4abc0d8bae7ff641bf8fbb0f72c25424</Hash>
</Codenesium>*/