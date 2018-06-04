using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class SalesOrderHeaderSalesReasonRepository: AbstractSalesOrderHeaderSalesReasonRepository, ISalesOrderHeaderSalesReasonRepository
	{
		public SalesOrderHeaderSalesReasonRepository(
			ILogger<SalesOrderHeaderSalesReasonRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>4593de33b9b5fcc05f1d2b3bdaa058d2</Hash>
</Codenesium>*/