using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class SalesPersonQuotaHistoryRepository: AbstractSalesPersonQuotaHistoryRepository, ISalesPersonQuotaHistoryRepository
	{
		public SalesPersonQuotaHistoryRepository(
			ILogger<SalesPersonQuotaHistoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>7a659b12f785b590afa1487b6860ffef</Hash>
</Codenesium>*/