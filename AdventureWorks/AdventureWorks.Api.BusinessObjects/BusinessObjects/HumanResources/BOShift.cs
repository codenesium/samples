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
			IApiShiftModelValidator shiftModelValidator)
			: base(logger, shiftRepository, shiftModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>b4444a0e1d812a2f1f08f9efd9dee822</Hash>
</Codenesium>*/