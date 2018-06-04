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
	public class EmployeeDepartmentHistoryService: AbstractEmployeeDepartmentHistoryService, IEmployeeDepartmentHistoryService
	{
		public EmployeeDepartmentHistoryService(
			ILogger<EmployeeDepartmentHistoryRepository> logger,
			IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository,
			IApiEmployeeDepartmentHistoryRequestModelValidator employeeDepartmentHistoryModelValidator,
			IBOLEmployeeDepartmentHistoryMapper BOLemployeeDepartmentHistoryMapper,
			IDALEmployeeDepartmentHistoryMapper DALemployeeDepartmentHistoryMapper)
			: base(logger, employeeDepartmentHistoryRepository,
			       employeeDepartmentHistoryModelValidator,
			       BOLemployeeDepartmentHistoryMapper,
			       DALemployeeDepartmentHistoryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>0541df945b2072691ccbcc2132d4b628</Hash>
</Codenesium>*/