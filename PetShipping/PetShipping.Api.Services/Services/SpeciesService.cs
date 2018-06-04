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
	public class SpeciesService: AbstractSpeciesService, ISpeciesService
	{
		public SpeciesService(
			ILogger<SpeciesRepository> logger,
			ISpeciesRepository speciesRepository,
			IApiSpeciesRequestModelValidator speciesModelValidator,
			IBOLSpeciesMapper BOLspeciesMapper,
			IDALSpeciesMapper DALspeciesMapper)
			: base(logger, speciesRepository,
			       speciesModelValidator,
			       BOLspeciesMapper,
			       DALspeciesMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>c538c99d0c7fc7bbbc597f767018dac7</Hash>
</Codenesium>*/