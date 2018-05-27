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
	public class BOBreed: AbstractBOBreed, IBOBreed
	{
		public BOBreed(
			ILogger<BreedRepository> logger,
			IBreedRepository breedRepository,
			IApiBreedRequestModelValidator breedModelValidator,
			IBOLBreedMapper breedMapper)
			: base(logger, breedRepository, breedModelValidator, breedMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>f73ba4e6be5437269e16f63455e6f031</Hash>
</Codenesium>*/