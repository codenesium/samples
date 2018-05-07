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
	public class OtherTransportRepository: AbstractOtherTransportRepository, IOtherTransportRepository
	{
		public OtherTransportRepository(
			IObjectMapper mapper,
			ILogger<OtherTransportRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>c5f694d8d806f58c0b920820a29f6e85</Hash>
</Codenesium>*/