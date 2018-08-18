using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>8b545af9cb15b6866c29b8302f004c9b</Hash>
</Codenesium>*/