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
			IShipMethodModelValidator shipMethodModelValidator)
			: base(logger, shipMethodRepository, shipMethodModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>a079b1c0004f85f255864e2122c7b9d5</Hash>
</Codenesium>*/