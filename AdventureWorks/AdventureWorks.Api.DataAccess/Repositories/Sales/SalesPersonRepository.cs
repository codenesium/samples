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
    <Hash>b9f08a79763d2c932d086c9e1d9ee6ae</Hash>
</Codenesium>*/