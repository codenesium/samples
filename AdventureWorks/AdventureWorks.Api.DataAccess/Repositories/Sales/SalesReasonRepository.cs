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
	public class SalesReasonRepository: AbstractSalesReasonRepository, ISalesReasonRepository
	{
		public SalesReasonRepository(
			IObjectMapper mapper,
			ILogger<SalesReasonRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>060afbcff6d2510b9fc46bfd9847ab7e</Hash>
</Codenesium>*/