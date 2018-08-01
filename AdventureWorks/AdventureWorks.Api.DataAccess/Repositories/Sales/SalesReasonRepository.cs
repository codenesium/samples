using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class SalesReasonRepository : AbstractSalesReasonRepository, ISalesReasonRepository
	{
		public SalesReasonRepository(
			ILogger<SalesReasonRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>eae340bc4147b52d70b785c530ed64ba</Hash>
</Codenesium>*/