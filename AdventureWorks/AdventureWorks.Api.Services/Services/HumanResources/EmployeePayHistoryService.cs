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
	public partial class EmployeePayHistoryService : AbstractEmployeePayHistoryService, IEmployeePayHistoryService
	{
		public EmployeePayHistoryService(
			ILogger<IEmployeePayHistoryRepository> logger,
			IEmployeePayHistoryRepository employeePayHistoryRepository,
			IApiEmployeePayHistoryRequestModelValidator employeePayHistoryModelValidator,
			IBOLEmployeePayHistoryMapper bolemployeePayHistoryMapper,
			IDALEmployeePayHistoryMapper dalemployeePayHistoryMapper
			)
			: base(logger,
			       employeePayHistoryRepository,
			       employeePayHistoryModelValidator,
			       bolemployeePayHistoryMapper,
			       dalemployeePayHistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>0e58d166a249c77c5dc8360ffd2c84c9</Hash>
</Codenesium>*/