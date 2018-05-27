using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class SalesPersonRepository: AbstractSalesPersonRepository, ISalesPersonRepository
	{
		public SalesPersonRepository(
			IDALSalesPersonMapper mapper,
			ILogger<SalesPersonRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>01c297a9c646a3b51637ee311fe3e9c8</Hash>
</Codenesium>*/