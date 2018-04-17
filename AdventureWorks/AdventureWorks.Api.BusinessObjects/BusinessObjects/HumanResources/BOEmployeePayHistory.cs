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
			IEmployeePayHistoryModelValidator employeePayHistoryModelValidator)
			: base(logger, employeePayHistoryRepository, employeePayHistoryModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>11afa472057e3616257e494dd5068a75</Hash>
</Codenesium>*/