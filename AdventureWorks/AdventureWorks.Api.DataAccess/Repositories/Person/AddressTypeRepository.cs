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
	public class AddressTypeRepository: AbstractAddressTypeRepository, IAddressTypeRepository
	{
		public AddressTypeRepository(
			IObjectMapper mapper,
			ILogger<AddressTypeRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>8e498e7df70c7a5bbea24404cb494dcf</Hash>
</Codenesium>*/