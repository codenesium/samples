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
			IApiSalesReasonRequestModelValidator salesReasonModelValidator,
			IBOLSalesReasonMapper salesReasonMapper)
			: base(logger, salesReasonRepository, salesReasonModelValidator, salesReasonMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>cf562817ef9a76d27ba3b3f4f5b887bf</Hash>
</Codenesium>*/