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
			IApiLocationRequestModelValidator locationModelValidator,
			IBOLLocationMapper locationMapper)
			: base(logger, locationRepository, locationModelValidator, locationMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>2382ed52c9b6d110d625a48d68803e48</Hash>
</Codenesium>*/