using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetStoreNS.Api.DataAccess
{
	public class SpeciesRepository: AbstractSpeciesRepository, ISpeciesRepository
	{
		public SpeciesRepository(
			ILogger<SpeciesRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>06975ccdc1cc5b39c0dfc0a3f3f13f89</Hash>
</Codenesium>*/