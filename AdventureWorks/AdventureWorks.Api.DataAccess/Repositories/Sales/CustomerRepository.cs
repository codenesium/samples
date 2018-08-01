using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class CustomerRepository : AbstractCustomerRepository, ICustomerRepository
	{
		public CustomerRepository(
			ILogger<CustomerRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>36e7dd8c51c9e4e5fd8dc4e688c9eef0</Hash>
</Codenesium>*/