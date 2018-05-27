using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class WorkOrderRepository: AbstractWorkOrderRepository, IWorkOrderRepository
	{
		public WorkOrderRepository(
			IDALWorkOrderMapper mapper,
			ILogger<WorkOrderRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>390606af0986e76d8d542bc4996c3b73</Hash>
</Codenesium>*/