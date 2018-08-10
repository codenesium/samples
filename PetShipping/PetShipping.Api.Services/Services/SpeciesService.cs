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
	public partial class SpeciesService : AbstractSpeciesService, ISpeciesService
	{
		public SpeciesService(
			ILogger<ISpeciesRepository> logger,
			ISpeciesRepository speciesRepository,
			IApiSpeciesRequestModelValidator speciesModelValidator,
			IBOLSpeciesMapper bolspeciesMapper,
			IDALSpeciesMapper dalspeciesMapper,
			IBOLBreedMapper bolBreedMapper,
			IDALBreedMapper dalBreedMapper
			)
			: base(logger,
			       speciesRepository,
			       speciesModelValidator,
			       bolspeciesMapper,
			       dalspeciesMapper,
			       bolBreedMapper,
			       dalBreedMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2b1782fcaf28baf0d7579ed7e0b502c0</Hash>
</Codenesium>*/