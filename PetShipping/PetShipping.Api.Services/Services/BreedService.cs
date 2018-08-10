using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
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
			IDALPetMapper dalPetMapper
			)
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
    <Hash>d427b9ec0422fb7b86cfad1cc384b066</Hash>
</Codenesium>*/