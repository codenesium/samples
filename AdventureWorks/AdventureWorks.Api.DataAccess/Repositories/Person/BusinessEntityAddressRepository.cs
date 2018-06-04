using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class BusinessEntityAddressRepository: AbstractBusinessEntityAddressRepository, IBusinessEntityAddressRepository
	{
		public BusinessEntityAddressRepository(
			ILogger<BusinessEntityAddressRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>7d7592a3a4087a2cec97885f81e487e7</Hash>
</Codenesium>*/