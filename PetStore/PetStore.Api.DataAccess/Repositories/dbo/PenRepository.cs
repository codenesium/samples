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
	public class PenRepository: AbstractPenRepository, IPenRepository
	{
		public PenRepository(
			IObjectMapper mapper,
			ILogger<PenRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>d24719a35b5b9945fe9e876953519ed8</Hash>
</Codenesium>*/