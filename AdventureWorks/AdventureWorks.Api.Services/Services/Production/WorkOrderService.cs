using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class WorkOrderService : AbstractWorkOrderService, IWorkOrderService
	{
		public WorkOrderService(
			ILogger<IWorkOrderRepository> logger,
			IMediator mediator,
			IWorkOrderRepository workOrderRepository,
			IApiWorkOrderServerRequestModelValidator workOrderModelValidator,
			IBOLWorkOrderMapper bolWorkOrderMapper,
			IDALWorkOrderMapper dalWorkOrderMapper)
			: base(logger,
			       mediator,
			       workOrderRepository,
			       workOrderModelValidator,
			       bolWorkOrderMapper,
			       dalWorkOrderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>79c9f86d6024e1b797e134fdbde44ea5</Hash>
</Codenesium>*/