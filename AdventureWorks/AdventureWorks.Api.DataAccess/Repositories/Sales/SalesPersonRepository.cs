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
	public partial class SalesPersonRepository : AbstractSalesPersonRepository, ISalesPersonRepository
	{
		public SalesPersonRepository(
			ILogger<SalesPersonRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9ec24d7c2dec97a5b069f6ed1ad3d2e0</Hash>
</Codenesium>*/