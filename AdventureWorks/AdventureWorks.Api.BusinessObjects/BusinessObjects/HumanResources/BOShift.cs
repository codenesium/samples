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
	public class BOShift: AbstractBOShift, IBOShift
	{
		public BOShift(
			ILogger<ShiftRepository> logger,
			IShiftRepository shiftRepository,
			IApiShiftRequestModelValidator shiftModelValidator,
			IBOLShiftMapper shiftMapper)
			: base(logger, shiftRepository, shiftModelValidator, shiftMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>5d37b3940bff80dc828c276e4b951dba</Hash>
</Codenesium>*/