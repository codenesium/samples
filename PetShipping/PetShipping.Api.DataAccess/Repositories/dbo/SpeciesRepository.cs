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
	public class SpeciesRepository: AbstractSpeciesRepository, ISpeciesRepository
	{
		public SpeciesRepository(
			IDALSpeciesMapper mapper,
			ILogger<SpeciesRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>554f60bea56c413761e5fd680d341041</Hash>
</Codenesium>*/