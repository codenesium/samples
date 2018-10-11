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
	public partial class ShiftService : AbstractShiftService, IShiftService
	{
		public ShiftService(
			ILogger<IShiftRepository> logger,
			IShiftRepository shiftRepository,
			IApiShiftRequestModelValidator shiftModelValidator,
			IBOLShiftMapper bolshiftMapper,
			IDALShiftMapper dalshiftMapper,
			IBOLEmployeeDepartmentHistoryMapper bolEmployeeDepartmentHistoryMapper,
			IDALEmployeeDepartmentHistoryMapper dalEmployeeDepartmentHistoryMapper)
			: base(logger,
			       shiftRepository,
			       shiftModelValidator,
			       bolshiftMapper,
			       dalshiftMapper,
			       bolEmployeeDepartmentHistoryMapper,
			       dalEmployeeDepartmentHistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>737581c30a3f85b33bcb83580caf99cb</Hash>
</Codenesium>*/