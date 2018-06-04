using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class EmployeePayHistoryService: AbstractEmployeePayHistoryService, IEmployeePayHistoryService
	{
		public EmployeePayHistoryService(
			ILogger<EmployeePayHistoryRepository> logger,
			IEmployeePayHistoryRepository employeePayHistoryRepository,
			IApiEmployeePayHistoryRequestModelValidator employeePayHistoryModelValidator,
			IBOLEmployeePayHistoryMapper BOLemployeePayHistoryMapper,
			IDALEmployeePayHistoryMapper DALemployeePayHistoryMapper)
			: base(logger, employeePayHistoryRepository,
			       employeePayHistoryModelValidator,
			       BOLemployeePayHistoryMapper,
			       DALemployeePayHistoryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>7dede1f4a728d58ea7a164eaeb1ab0ec</Hash>
</Codenesium>*/