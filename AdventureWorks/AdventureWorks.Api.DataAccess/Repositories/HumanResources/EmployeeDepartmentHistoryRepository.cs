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
	public class EmployeeDepartmentHistoryRepository: AbstractEmployeeDepartmentHistoryRepository, IEmployeeDepartmentHistoryRepository
	{
		public EmployeeDepartmentHistoryRepository(
			IObjectMapper mapper,
			ILogger<EmployeeDepartmentHistoryRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>ce9dd7df11df7e2e8a4bd020e6cb9093</Hash>
</Codenesium>*/