using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class BusinessEntityRepository: AbstractBusinessEntityRepository, IBusinessEntityRepository
	{
		public BusinessEntityRepository(
			ILogger<BusinessEntityRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>1e9f99f037516eda45d62f14d24d2cba</Hash>
</Codenesium>*/