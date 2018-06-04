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
	public class SalesReasonService: AbstractSalesReasonService, ISalesReasonService
	{
		public SalesReasonService(
			ILogger<SalesReasonRepository> logger,
			ISalesReasonRepository salesReasonRepository,
			IApiSalesReasonRequestModelValidator salesReasonModelValidator,
			IBOLSalesReasonMapper BOLsalesReasonMapper,
			IDALSalesReasonMapper DALsalesReasonMapper)
			: base(logger, salesReasonRepository,
			       salesReasonModelValidator,
			       BOLsalesReasonMapper,
			       DALsalesReasonMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>51cd2aa37f702050f4ee34aefb6657ab</Hash>
</Codenesium>*/