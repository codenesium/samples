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
	public class BreedRepository: AbstractBreedRepository, IBreedRepository
	{
		public BreedRepository(
			IDALBreedMapper mapper,
			ILogger<BreedRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>0b61642c627481ac36d392901d040722</Hash>
</Codenesium>*/