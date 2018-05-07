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
	public class HandlerRepository: AbstractHandlerRepository, IHandlerRepository
	{
		public HandlerRepository(
			IObjectMapper mapper,
			ILogger<HandlerRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>f9d5d7f8fd015e99f5a3c5bb5cf6b2db</Hash>
</Codenesium>*/