using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public class DestinationRepository: AbstractDestinationRepository, IDestinationRepository
	{
		public DestinationRepository(
			IObjectMapper mapper,
			ILogger<DestinationRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>fe422636a7b3dc4db3d8bd4a1b11c762</Hash>
</Codenesium>*/