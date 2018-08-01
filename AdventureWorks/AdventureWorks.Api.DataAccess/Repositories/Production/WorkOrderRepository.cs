using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>000e9502a150ea5b0a1ee30a43efde0e</Hash>
</Codenesium>*/