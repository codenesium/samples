using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
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
    <Hash>71e7d2f0afefd6c358e2eac4bca43eae</Hash>
</Codenesium>*/