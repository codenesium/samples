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
	public class ShiftService: AbstractShiftService, IShiftService
	{
		public ShiftService(
			ILogger<ShiftRepository> logger,
			IShiftRepository shiftRepository,
			IApiShiftRequestModelValidator shiftModelValidator,
			IBOLShiftMapper BOLshiftMapper,
			IDALShiftMapper DALshiftMapper)
			: base(logger, shiftRepository,
			       shiftModelValidator,
			       BOLshiftMapper,
			       DALshiftMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>065ef5de5a9a7b1fdbe30597c7989c53</Hash>
</Codenesium>*/