using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public class BOSpecies: AbstractBOSpecies, IBOSpecies
	{
		public BOSpecies(
			ILogger<SpeciesRepository> logger,
			ISpeciesRepository speciesRepository,
			ISpeciesModelValidator speciesModelValidator)
			: base(logger, speciesRepository, speciesModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>cb47de7afc11a4ee3c9bbd3218747fb6</Hash>
</Codenesium>*/