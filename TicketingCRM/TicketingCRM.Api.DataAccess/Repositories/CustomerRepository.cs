using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.DataAccess
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
    <Hash>1d7fd1e636a23ba9e4719d2ed0de0252</Hash>
</Codenesium>*/