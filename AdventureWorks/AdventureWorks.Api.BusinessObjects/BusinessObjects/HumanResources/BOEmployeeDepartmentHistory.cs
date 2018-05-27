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
			IApiEmployeeDepartmentHistoryRequestModelValidator employeeDepartmentHistoryModelValidator,
			IBOLEmployeeDepartmentHistoryMapper employeeDepartmentHistoryMapper)
			: base(logger, employeeDepartmentHistoryRepository, employeeDepartmentHistoryModelValidator, employeeDepartmentHistoryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>fa04d5f6e1ce8f8d112bfbe2e541707d</Hash>
</Codenesium>*/