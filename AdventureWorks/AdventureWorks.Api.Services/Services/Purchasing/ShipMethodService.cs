using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ShipMethodService: AbstractShipMethodService, IShipMethodService
	{
		public ShipMethodService(
			ILogger<ShipMethodRepository> logger,
			IShipMethodRepository shipMethodRepository,
			IApiShipMethodRequestModelValidator shipMethodModelValidator,
			IBOLShipMethodMapper BOLshipMethodMapper,
			IDALShipMethodMapper DALshipMethodMapper)
			: base(logger, shipMethodRepository,
			       shipMethodModelValidator,
			       BOLshipMethodMapper,
			       DALshipMethodMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>90459f97ed79b1ae02650baa8d23962e</Hash>
</Codenesium>*/