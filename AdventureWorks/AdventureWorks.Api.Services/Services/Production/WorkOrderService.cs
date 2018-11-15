using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class WorkOrderService : AbstractWorkOrderService, IWorkOrderService
	{
		public WorkOrderService(
			ILogger<IWorkOrderRepository> logger,
			IWorkOrderRepository workOrderRepository,
			IApiWorkOrderServerRequestModelValidator workOrderModelValidator,
			IBOLWorkOrderMapper bolWorkOrderMapper,
			IDALWorkOrderMapper dalWorkOrderMapper)
			: base(logger,
			       workOrderRepository,
			       workOrderModelValidator,
			       bolWorkOrderMapper,
			       dalWorkOrderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a26281529556a622eb7aa6c1cdae7164</Hash>
</Codenesium>*/