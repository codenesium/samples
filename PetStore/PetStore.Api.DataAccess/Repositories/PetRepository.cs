using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetStoreNS.Api.DataAccess
{
	public class PetRepository: AbstractPetRepository, IPetRepository
	{
		public PetRepository(
			ILogger<PetRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>70142be52f57cd458dee6943f85bbbef</Hash>
</Codenesium>*/