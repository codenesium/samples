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
			IDALBusinessEntityMapper mapper,
			ILogger<BusinessEntityRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>5d672988ad35afa275b1ad01b9d52cd6</Hash>
</Codenesium>*/