using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class AddressRepository : AbstractAddressRepository, IAddressRepository
	{
		public AddressRepository(
			ILogger<AddressRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c6b817160fc4cacb5bacc2c9388f7f22</Hash>
</Codenesium>*/