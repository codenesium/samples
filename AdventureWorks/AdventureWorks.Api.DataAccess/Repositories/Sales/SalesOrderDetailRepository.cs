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
	public partial class SalesOrderDetailRepository : AbstractSalesOrderDetailRepository, ISalesOrderDetailRepository
	{
		public SalesOrderDetailRepository(
			ILogger<SalesOrderDetailRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b204d9cc56304032d6f8e36b5a8ccd65</Hash>
</Codenesium>*/