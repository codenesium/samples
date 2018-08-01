using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class WorkOrderService : AbstractWorkOrderService, IWorkOrderService
	{
		public WorkOrderService(
			ILogger<IWorkOrderRepository> logger,
			IWorkOrderRepository workOrderRepository,
			IApiWorkOrderRequestModelValidator workOrderModelValidator,
			IBOLWorkOrderMapper bolworkOrderMapper,
			IDALWorkOrderMapper dalworkOrderMapper,
			IBOLWorkOrderRoutingMapper bolWorkOrderRoutingMapper,
			IDALWorkOrderRoutingMapper dalWorkOrderRoutingMapper
			)
			: base(logger,
			       workOrderRepository,
			       workOrderModelValidator,
			       bolworkOrderMapper,
			       dalworkOrderMapper,
			       bolWorkOrderRoutingMapper,
			       dalWorkOrderRoutingMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b31fba3b88618d9bcd99cce5c8d3996f</Hash>
</Codenesium>*/