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
	public class WorkOrderRoutingRepository: AbstractWorkOrderRoutingRepository, IWorkOrderRoutingRepository
	{
		public WorkOrderRoutingRepository(
			IDALWorkOrderRoutingMapper mapper,
			ILogger<WorkOrderRoutingRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>7dfe7f4939c77eb7324382348c6e4f44</Hash>
</Codenesium>*/