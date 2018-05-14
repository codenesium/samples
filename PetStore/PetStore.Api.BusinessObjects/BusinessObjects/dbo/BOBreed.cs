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
			IApiBreedModelValidator breedModelValidator)
			: base(logger, breedRepository, breedModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>1539b9f626c84db32c0aeb639213738c</Hash>
</Codenesium>*/