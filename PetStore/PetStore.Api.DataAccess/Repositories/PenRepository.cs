using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetStoreNS.Api.DataAccess
{
	public class PenRepository: AbstractPenRepository, IPenRepository
	{
		public PenRepository(
			ILogger<PenRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>ecf8a2a1d69b07a901e3037726b48876</Hash>
</Codenesium>*/