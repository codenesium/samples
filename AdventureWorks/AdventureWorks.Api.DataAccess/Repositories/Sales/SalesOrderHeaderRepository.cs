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
	public partial class SalesOrderHeaderRepository : AbstractSalesOrderHeaderRepository, ISalesOrderHeaderRepository
	{
		public SalesOrderHeaderRepository(
			ILogger<SalesOrderHeaderRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>46bd53a746480dc2f7208509ec8540a6</Hash>
</Codenesium>*/