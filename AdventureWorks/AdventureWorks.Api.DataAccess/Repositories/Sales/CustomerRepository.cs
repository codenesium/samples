using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>9a6e4bfc1f7e5b5830f03437ed220767</Hash>
</Codenesium>*/