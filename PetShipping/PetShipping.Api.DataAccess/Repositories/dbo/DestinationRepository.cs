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
			IDALDestinationMapper mapper,
			ILogger<DestinationRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>868ab0fa170ccca9ed56c89747cae2cb</Hash>
</Codenesium>*/