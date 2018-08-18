using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>b4ef927c6bf2c7197afae09b78a05f60</Hash>
</Codenesium>*/