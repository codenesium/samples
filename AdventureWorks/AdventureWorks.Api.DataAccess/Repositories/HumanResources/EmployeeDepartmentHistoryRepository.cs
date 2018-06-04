using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class EmployeeDepartmentHistoryRepository: AbstractEmployeeDepartmentHistoryRepository, IEmployeeDepartmentHistoryRepository
	{
		public EmployeeDepartmentHistoryRepository(
			ILogger<EmployeeDepartmentHistoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>df375537b5764e1982b3cdf32ee2b24a</Hash>
</Codenesium>*/