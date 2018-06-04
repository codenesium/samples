using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
	public class BreedRepository: AbstractBreedRepository, IBreedRepository
	{
		public BreedRepository(
			ILogger<BreedRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>dde53b886850a0e1dc3281341cc24947</Hash>
</Codenesium>*/