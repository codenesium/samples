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
	public class BreedRepository: AbstractBreedRepository, IBreedRepository
	{
		public BreedRepository(
			IDALBreedMapper mapper,
			ILogger<BreedRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>2cbb9c188dde05052d168ed25b42ba4a</Hash>
</Codenesium>*/