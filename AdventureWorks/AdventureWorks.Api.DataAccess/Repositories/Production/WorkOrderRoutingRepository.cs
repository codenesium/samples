using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class WorkOrderRoutingRepository : AbstractWorkOrderRoutingRepository, IWorkOrderRoutingRepository
	{
		public WorkOrderRoutingRepository(
			ILogger<WorkOrderRoutingRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f141f609287815394abb3d1d8479c0b0</Hash>
</Codenesium>*/