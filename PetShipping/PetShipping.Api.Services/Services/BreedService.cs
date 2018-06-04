using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public class BreedService: AbstractBreedService, IBreedService
	{
		public BreedService(
			ILogger<BreedRepository> logger,
			IBreedRepository breedRepository,
			IApiBreedRequestModelValidator breedModelValidator,
			IBOLBreedMapper BOLbreedMapper,
			IDALBreedMapper DALbreedMapper)
			: base(logger, breedRepository,
			       breedModelValidator,
			       BOLbreedMapper,
			       DALbreedMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>ba8b54aea2b6bde6f6c55d548ae02329</Hash>
</Codenesium>*/