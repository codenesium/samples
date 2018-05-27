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
	public class PetRepository: AbstractPetRepository, IPetRepository
	{
		public PetRepository(
			IDALPetMapper mapper,
			ILogger<PetRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>badb38d18d9b1c3976c6f5cc2934ec70</Hash>
</Codenesium>*/