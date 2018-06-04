using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
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
    <Hash>cf6a3ea92df37cfdd9fb8ad7b8b941ce</Hash>
</Codenesium>*/