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
			IDALHandlerMapper mapper,
			ILogger<HandlerRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>73e0b94d57ab04cf067605e303d64e44</Hash>
</Codenesium>*/