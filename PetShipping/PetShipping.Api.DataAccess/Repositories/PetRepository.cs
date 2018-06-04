using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
	public class PetRepository: AbstractPetRepository, IPetRepository
	{
		public PetRepository(
			ILogger<PetRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>13cfd62fd7351483a53e1b755e94f64b</Hash>
</Codenesium>*/