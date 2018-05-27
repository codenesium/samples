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
			IApiWorkOrderRoutingRequestModelValidator workOrderRoutingModelValidator,
			IBOLWorkOrderRoutingMapper workOrderRoutingMapper)
			: base(logger, workOrderRoutingRepository, workOrderRoutingModelValidator, workOrderRoutingMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>dc6c13bab4b8b2fd3b1f3c9009040b9d</Hash>
</Codenesium>*/