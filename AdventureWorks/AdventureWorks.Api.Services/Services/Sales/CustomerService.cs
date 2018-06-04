using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class CustomerService: AbstractCustomerService, ICustomerService
	{
		public CustomerService(
			ILogger<CustomerRepository> logger,
			ICustomerRepository customerRepository,
			IApiCustomerRequestModelValidator customerModelValidator,
			IBOLCustomerMapper BOLcustomerMapper,
			IDALCustomerMapper DALcustomerMapper)
			: base(logger, customerRepository,
			       customerModelValidator,
			       BOLcustomerMapper,
			       DALcustomerMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>4ebbef3da21aaf83deae7cbf75d5d24b</Hash>
</Codenesium>*/