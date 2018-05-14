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
			IApiCustomerModelValidator customerModelValidator)
			: base(logger, customerRepository, customerModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>40dbec5acc67812241fbe79a08d2f5b4</Hash>
</Codenesium>*/