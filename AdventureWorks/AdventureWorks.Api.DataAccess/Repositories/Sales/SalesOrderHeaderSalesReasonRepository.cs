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
	public class SalesOrderHeaderSalesReasonRepository: AbstractSalesOrderHeaderSalesReasonRepository, ISalesOrderHeaderSalesReasonRepository
	{
		public SalesOrderHeaderSalesReasonRepository(
			IObjectMapper mapper,
			ILogger<SalesOrderHeaderSalesReasonRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>ad4a969348f5f21dbde41eb4d0aa1527</Hash>
</Codenesium>*/