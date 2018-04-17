using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOEmployeeDepartmentHistory: AbstractBOEmployeeDepartmentHistory, IBOEmployeeDepartmentHistory
	{
		public BOEmployeeDepartmentHistory(
			ILogger<EmployeeDepartmentHistoryRepository> logger,
			IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository,
			IEmployeeDepartmentHistoryModelValidator employeeDepartmentHistoryModelValidator)
			: base(logger, employeeDepartmentHistoryRepository, employeeDepartmentHistoryModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>6c5884964c85d9d89aa93135eb3cc44b</Hash>
</Codenesium>*/