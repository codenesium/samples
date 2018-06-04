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
	public class WorkOrderService: AbstractWorkOrderService, IWorkOrderService
	{
		public WorkOrderService(
			ILogger<WorkOrderRepository> logger,
			IWorkOrderRepository workOrderRepository,
			IApiWorkOrderRequestModelValidator workOrderModelValidator,
			IBOLWorkOrderMapper BOLworkOrderMapper,
			IDALWorkOrderMapper DALworkOrderMapper)
			: base(logger, workOrderRepository,
			       workOrderModelValidator,
			       BOLworkOrderMapper,
			       DALworkOrderMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>b48aed41b8a8262ab4e1cfdb3a31bfc5</Hash>
</Codenesium>*/