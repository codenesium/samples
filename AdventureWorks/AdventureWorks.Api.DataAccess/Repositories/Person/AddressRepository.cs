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
    <Hash>ce1391ae7a1e7c5ab5f71c14b406a418</Hash>
</Codenesium>*/