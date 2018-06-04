using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class CustomerRepository: AbstractCustomerRepository, ICustomerRepository
	{
		public CustomerRepository(
			ILogger<CustomerRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>4847ecc9dca6134e3e24d9acbab940cf</Hash>
</Codenesium>*/