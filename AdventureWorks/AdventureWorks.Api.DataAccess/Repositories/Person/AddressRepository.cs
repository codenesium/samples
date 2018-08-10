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
    <Hash>6e07fec4c97b5e9c53e9b58fc35a831d</Hash>
</Codenesium>*/