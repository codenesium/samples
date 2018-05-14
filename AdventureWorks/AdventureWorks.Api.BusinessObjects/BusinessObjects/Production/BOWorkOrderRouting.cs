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
	public class BOWorkOrderRouting: AbstractBOWorkOrderRouting, IBOWorkOrderRouting
	{
		public BOWorkOrderRouting(
			ILogger<WorkOrderRoutingRepository> logger,
			IWorkOrderRoutingRepository workOrderRoutingRepository,
			IApiWorkOrderRoutingModelValidator workOrderRoutingModelValidator)
			: base(logger, workOrderRoutingRepository, workOrderRoutingModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>0e486f7d76917066f20cae2f7aa30197</Hash>
</Codenesium>*/