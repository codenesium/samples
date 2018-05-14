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
			IApiBreedModelValidator breedModelValidator)
			: base(logger, breedRepository, breedModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>19b2fbf0dbc9447fd2789000dc4c40da</Hash>
</Codenesium>*/