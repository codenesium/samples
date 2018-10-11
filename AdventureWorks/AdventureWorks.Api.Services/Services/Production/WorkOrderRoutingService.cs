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
	public partial class WorkOrderRoutingService : AbstractWorkOrderRoutingService, IWorkOrderRoutingService
	{
		public WorkOrderRoutingService(
			ILogger<IWorkOrderRoutingRepository> logger,
			IWorkOrderRoutingRepository workOrderRoutingRepository,
			IApiWorkOrderRoutingRequestModelValidator workOrderRoutingModelValidator,
			IBOLWorkOrderRoutingMapper bolworkOrderRoutingMapper,
			IDALWorkOrderRoutingMapper dalworkOrderRoutingMapper)
			: base(logger,
			       workOrderRoutingRepository,
			       workOrderRoutingModelValidator,
			       bolworkOrderRoutingMapper,
			       dalworkOrderRoutingMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>bc7642abed1cae2790a7bd63edc0291d</Hash>
</Codenesium>*/