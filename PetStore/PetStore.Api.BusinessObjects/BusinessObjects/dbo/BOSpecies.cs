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
			IApiSpeciesRequestModelValidator speciesModelValidator,
			IBOLSpeciesMapper speciesMapper)
			: base(logger, speciesRepository, speciesModelValidator, speciesMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>82b8e394e170cb669cd46657a0da0f04</Hash>
</Codenesium>*/