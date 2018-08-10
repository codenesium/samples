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
    <Hash>5053a5724de68bd84fb948493d963ad9</Hash>
</Codenesium>*/