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
	public class CustomerRepository: AbstractCustomerRepository, ICustomerRepository
	{
		public CustomerRepository(
			IObjectMapper mapper,
			ILogger<CustomerRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>b8a51711908168c0381a3a89fc9295d1</Hash>
</Codenesium>*/