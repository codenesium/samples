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
			ISpeciesModelValidator speciesModelValidator)
			: base(logger, speciesRepository, speciesModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>ed6afd51a051efbb4f2ccdfaa8ec9cdb</Hash>
</Codenesium>*/