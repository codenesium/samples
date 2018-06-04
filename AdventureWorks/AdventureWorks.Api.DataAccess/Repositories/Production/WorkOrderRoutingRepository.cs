using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class WorkOrderRoutingRepository: AbstractWorkOrderRoutingRepository, IWorkOrderRoutingRepository
	{
		public WorkOrderRoutingRepository(
			ILogger<WorkOrderRoutingRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>91fcfba866b55441a7e60333460c43ac</Hash>
</Codenesium>*/