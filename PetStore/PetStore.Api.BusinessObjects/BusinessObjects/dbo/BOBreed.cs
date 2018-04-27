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
			IBreedModelValidator breedModelValidator)
			: base(logger, breedRepository, breedModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>e95ca9391dd88854e5ca670a3bbe7769</Hash>
</Codenesium>*/