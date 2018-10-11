using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial class BreedService : AbstractBreedService, IBreedService
	{
		public BreedService(
			ILogger<IBreedRepository> logger,
			IBreedRepository breedRepository,
			IApiBreedRequestModelValidator breedModelValidator,
			IBOLBreedMapper bolbreedMapper,
			IDALBreedMapper dalbreedMapper,
			IBOLPetMapper bolPetMapper,
			IDALPetMapper dalPetMapper)
			: base(logger,
			       breedRepository,
			       breedModelValidator,
			       bolbreedMapper,
			       dalbreedMapper,
			       bolPetMapper,
			       dalPetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6dda68f99a2917eb818694f0236c7222</Hash>
</Codenesium>*/