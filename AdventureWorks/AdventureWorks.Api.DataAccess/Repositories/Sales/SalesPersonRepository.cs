using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>bcc1a5a90868a853c2ef112a30166177</Hash>
</Codenesium>*/