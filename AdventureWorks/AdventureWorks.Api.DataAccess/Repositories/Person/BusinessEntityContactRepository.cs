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
	public class BusinessEntityContactRepository: AbstractBusinessEntityContactRepository, IBusinessEntityContactRepository
	{
		public BusinessEntityContactRepository(
			IObjectMapper mapper,
			ILogger<BusinessEntityContactRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>e9bfda22dfb808c541107b7610ad112c</Hash>
</Codenesium>*/