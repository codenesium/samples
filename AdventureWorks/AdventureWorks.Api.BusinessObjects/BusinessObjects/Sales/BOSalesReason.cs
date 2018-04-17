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
	public class BOSalesReason: AbstractBOSalesReason, IBOSalesReason
	{
		public BOSalesReason(
			ILogger<SalesReasonRepository> logger,
			ISalesReasonRepository salesReasonRepository,
			ISalesReasonModelValidator salesReasonModelValidator)
			: base(logger, salesReasonRepository, salesReasonModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>23c279515ca59a6081cdfdc089612952</Hash>
</Codenesium>*/