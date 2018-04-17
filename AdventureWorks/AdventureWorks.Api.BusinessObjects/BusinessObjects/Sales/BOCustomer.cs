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
			ICustomerModelValidator customerModelValidator)
			: base(logger, customerRepository, customerModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>67f1efae805b14e29d4b48345379acb9</Hash>
</Codenesium>*/