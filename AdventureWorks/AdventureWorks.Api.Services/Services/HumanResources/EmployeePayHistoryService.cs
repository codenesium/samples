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
    <Hash>5f72d39834b298f861b4a9eb10aaa6a3</Hash>
</Codenesium>*/