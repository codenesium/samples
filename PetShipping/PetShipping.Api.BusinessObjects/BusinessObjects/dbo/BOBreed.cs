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
	public class BOBreed: AbstractBOBreed, IBOBreed
	{
		public BOBreed(
			ILogger<BreedRepository> logger,
			IBreedRepository breedRepository,
			IBreedModelValidator breedModelValidator)
			: base(logger, breedRepository, breedModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>317a40d55e897b1e9ea1178b9eb4c2e6</Hash>
</Codenesium>*/