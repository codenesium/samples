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
	public class BOShipMethod: AbstractBOShipMethod, IBOShipMethod
	{
		public BOShipMethod(
			ILogger<ShipMethodRepository> logger,
			IShipMethodRepository shipMethodRepository,
			IApiShipMethodModelValidator shipMethodModelValidator)
			: base(logger, shipMethodRepository, shipMethodModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>38638f4fcfb3c84ac43577396e9e9e71</Hash>
</Codenesium>*/