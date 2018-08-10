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
	public partial class SalesOrderHeaderSalesReasonRepository : AbstractSalesOrderHeaderSalesReasonRepository, ISalesOrderHeaderSalesReasonRepository
	{
		public SalesOrderHeaderSalesReasonRepository(
			ILogger<SalesOrderHeaderSalesReasonRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3736c12841c7a844ccd22d93e0168217</Hash>
</Codenesium>*/