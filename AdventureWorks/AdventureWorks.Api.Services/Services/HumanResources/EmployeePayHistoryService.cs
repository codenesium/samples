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
			IDALEmployeePayHistoryMapper dalemployeePayHistoryMapper)
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
    <Hash>1cfc7d8b1a894a52c46c70ecdad5c35b</Hash>
</Codenesium>*/