using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOCustomer: AbstractBOCustomer, IBOCustomer
	{
		public BOCustomer(
			ILogger<CustomerRepository> logger,
			ICustomerRepository customerRepository,
			IApiCustomerRequestModelValidator customerModelValidator,
			IBOLCustomerMapper customerMapper)
			: base(logger, customerRepository, customerModelValidator, customerMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>57c148e8b9cf5d0d6d04d4e4f03fabc2</Hash>
</Codenesium>*/