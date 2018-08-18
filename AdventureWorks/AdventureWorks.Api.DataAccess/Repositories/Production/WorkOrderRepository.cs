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
	public partial class WorkOrderRepository : AbstractWorkOrderRepository, IWorkOrderRepository
	{
		public WorkOrderRepository(
			ILogger<WorkOrderRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>375326111f013a9857f7b885c5d8e3d6</Hash>
</Codenesium>*/