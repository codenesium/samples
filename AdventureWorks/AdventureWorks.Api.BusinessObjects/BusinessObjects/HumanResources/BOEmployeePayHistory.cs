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
	public class BOEmployeePayHistory: AbstractBOEmployeePayHistory, IBOEmployeePayHistory
	{
		public BOEmployeePayHistory(
			ILogger<EmployeePayHistoryRepository> logger,
			IEmployeePayHistoryRepository employeePayHistoryRepository,
			IApiEmployeePayHistoryRequestModelValidator employeePayHistoryModelValidator,
			IBOLEmployeePayHistoryMapper employeePayHistoryMapper)
			: base(logger, employeePayHistoryRepository, employeePayHistoryModelValidator, employeePayHistoryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>4bb1deec719e4c1e3ce20130d3809238</Hash>
</Codenesium>*/