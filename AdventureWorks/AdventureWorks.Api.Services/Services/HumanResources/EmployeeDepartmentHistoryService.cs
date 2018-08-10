using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class EmployeeDepartmentHistoryService : AbstractEmployeeDepartmentHistoryService, IEmployeeDepartmentHistoryService
	{
		public EmployeeDepartmentHistoryService(
			ILogger<IEmployeeDepartmentHistoryRepository> logger,
			IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository,
			IApiEmployeeDepartmentHistoryRequestModelValidator employeeDepartmentHistoryModelValidator,
			IBOLEmployeeDepartmentHistoryMapper bolemployeeDepartmentHistoryMapper,
			IDALEmployeeDepartmentHistoryMapper dalemployeeDepartmentHistoryMapper
			)
			: base(logger,
			       employeeDepartmentHistoryRepository,
			       employeeDepartmentHistoryModelValidator,
			       bolemployeeDepartmentHistoryMapper,
			       dalemployeeDepartmentHistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b926db69e1f5189e0224a81c0f16f7f7</Hash>
</Codenesium>*/