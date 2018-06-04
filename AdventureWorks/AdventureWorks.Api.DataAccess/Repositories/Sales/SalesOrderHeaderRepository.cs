using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class SalesOrderHeaderRepository: AbstractSalesOrderHeaderRepository, ISalesOrderHeaderRepository
	{
		public SalesOrderHeaderRepository(
			ILogger<SalesOrderHeaderRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>684688cb209b55a7a4c1cc3ecc434b28</Hash>
</Codenesium>*/