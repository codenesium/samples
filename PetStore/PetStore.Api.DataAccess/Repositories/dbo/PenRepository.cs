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
			IDALPenMapper mapper,
			ILogger<PenRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>0c6f063a1f60d1289912033c14e12281</Hash>
</Codenesium>*/