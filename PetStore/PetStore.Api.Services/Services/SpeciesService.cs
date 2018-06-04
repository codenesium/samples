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
    <Hash>f1bcd5a7e2b93479a6ff241229221acd</Hash>
</Codenesium>*/