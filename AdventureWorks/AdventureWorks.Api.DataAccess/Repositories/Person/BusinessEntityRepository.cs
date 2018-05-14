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
	public class BusinessEntityRepository: AbstractBusinessEntityRepository, IBusinessEntityRepository
	{
		public BusinessEntityRepository(
			IObjectMapper mapper,
			ILogger<BusinessEntityRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>8684193f70c06b59654860e9c3ac070a</Hash>
</Codenesium>*/