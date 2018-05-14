using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class SalesPersonQuotaHistoryRepository: AbstractSalesPersonQuotaHistoryRepository, ISalesPersonQuotaHistoryRepository
	{
		public SalesPersonQuotaHistoryRepository(
			IObjectMapper mapper,
			ILogger<SalesPersonQuotaHistoryRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>6ea6425561029c4e6d7c6499ca2aeb2c</Hash>
</Codenesium>*/