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
			IWorkOrderRoutingModelValidator workOrderRoutingModelValidator)
			: base(logger, workOrderRoutingRepository, workOrderRoutingModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>d72ed2da12e21490de34e699e5d6e9b7</Hash>
</Codenesium>*/