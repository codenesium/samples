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
			IApiEmployeeDepartmentHistoryModelValidator employeeDepartmentHistoryModelValidator)
			: base(logger, employeeDepartmentHistoryRepository, employeeDepartmentHistoryModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>65bdc6432211b839d1f7764169f4e947</Hash>
</Codenesium>*/