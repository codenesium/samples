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
    <Hash>4e7aff65e2682ba387357079666db2a2</Hash>
</Codenesium>*/