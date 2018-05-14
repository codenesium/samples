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
			IApiSpeciesModelValidator speciesModelValidator)
			: base(logger, speciesRepository, speciesModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>a922550c6e61a3c557e7e84dd76b16d5</Hash>
</Codenesium>*/