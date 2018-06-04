using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class SalesOrderDetailRepository: AbstractSalesOrderDetailRepository, ISalesOrderDetailRepository
	{
		public SalesOrderDetailRepository(
			ILogger<SalesOrderDetailRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>cbc5607f7c9bb7d7567e1afc57ebf780</Hash>
</Codenesium>*/