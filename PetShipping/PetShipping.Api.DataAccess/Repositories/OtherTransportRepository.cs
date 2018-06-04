using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
	public class OtherTransportRepository: AbstractOtherTransportRepository, IOtherTransportRepository
	{
		public OtherTransportRepository(
			ILogger<OtherTransportRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>4512c6a593f06f87ca4f57c87e2ecf36</Hash>
</Codenesium>*/