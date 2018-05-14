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
	public class BusinessEntityAddressRepository: AbstractBusinessEntityAddressRepository, IBusinessEntityAddressRepository
	{
		public BusinessEntityAddressRepository(
			IObjectMapper mapper,
			ILogger<BusinessEntityAddressRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>124e67ebd387a7a19a376100d3f7d1e1</Hash>
</Codenesium>*/