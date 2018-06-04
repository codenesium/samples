using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class SalesReasonRepository: AbstractSalesReasonRepository, ISalesReasonRepository
	{
		public SalesReasonRepository(
			ILogger<SalesReasonRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>149d591a8a255316b30ac4f0bc41c5e3</Hash>
</Codenesium>*/