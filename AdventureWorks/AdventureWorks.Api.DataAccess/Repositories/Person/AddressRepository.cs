using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class AddressRepository: AbstractAddressRepository, IAddressRepository
	{
		public AddressRepository(
			IDALAddressMapper mapper,
			ILogger<AddressRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>dbb6fc0ca061ca922e4461f800eabcb3</Hash>
</Codenesium>*/