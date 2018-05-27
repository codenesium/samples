using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public class SpeciesRepository: AbstractSpeciesRepository, ISpeciesRepository
	{
		public SpeciesRepository(
			IDALSpeciesMapper mapper,
			ILogger<SpeciesRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>8335cf5498b63aaf70e63a1bc55051ea</Hash>
</Codenesium>*/