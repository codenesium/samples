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
	public partial class AddressTypeRepository : AbstractAddressTypeRepository, IAddressTypeRepository
	{
		public AddressTypeRepository(
			ILogger<AddressTypeRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>31e4515b25cddbcd152cef6093ca2191</Hash>
</Codenesium>*/