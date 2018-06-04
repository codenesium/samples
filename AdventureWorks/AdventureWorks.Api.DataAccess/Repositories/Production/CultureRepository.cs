using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class CultureRepository: AbstractCultureRepository, ICultureRepository
	{
		public CultureRepository(
			ILogger<CultureRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>2a596d8b55b915e72c265604cb3058ec</Hash>
</Codenesium>*/