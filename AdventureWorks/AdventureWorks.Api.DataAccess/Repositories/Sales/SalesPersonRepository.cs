using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class SalesPersonRepository: AbstractSalesPersonRepository, ISalesPersonRepository
	{
		public SalesPersonRepository(
			ILogger<SalesPersonRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>7c32431780208b547e453869332432c9</Hash>
</Codenesium>*/