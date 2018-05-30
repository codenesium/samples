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
			IDALOtherTransportMapper mapper,
			ILogger<OtherTransportRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>c363b1f809158dce9ab4cd7207579c97</Hash>
</Codenesium>*/