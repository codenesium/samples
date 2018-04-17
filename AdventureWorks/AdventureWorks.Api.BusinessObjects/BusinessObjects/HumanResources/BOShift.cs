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
			IShiftModelValidator shiftModelValidator)
			: base(logger, shiftRepository, shiftModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>90ff9f6b0e5627ab4b0129ef2ebea022</Hash>
</Codenesium>*/