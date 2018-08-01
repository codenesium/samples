using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>0175c8a61f4ab43929f0faad64cc179d</Hash>
</Codenesium>*/