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
			IApiShipMethodRequestModelValidator shipMethodModelValidator,
			IBOLShipMethodMapper shipMethodMapper)
			: base(logger, shipMethodRepository, shipMethodModelValidator, shipMethodMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>05df9abcacdefa870aba7aa8caba0950</Hash>
</Codenesium>*/