using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class WorkOrderRepository: AbstractWorkOrderRepository, IWorkOrderRepository
	{
		public WorkOrderRepository(
			ILogger<WorkOrderRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>32b235d5ba57e04f9dc085eb606fc9bb</Hash>
</Codenesium>*/