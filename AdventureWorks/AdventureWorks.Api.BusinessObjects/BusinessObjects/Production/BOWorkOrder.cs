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
	public class BOWorkOrder: AbstractBOWorkOrder, IBOWorkOrder
	{
		public BOWorkOrder(
			ILogger<WorkOrderRepository> logger,
			IWorkOrderRepository workOrderRepository,
			IApiWorkOrderModelValidator workOrderModelValidator)
			: base(logger, workOrderRepository, workOrderModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>cd42d2d302aecfb86168aa03f7a35e71</Hash>
</Codenesium>*/