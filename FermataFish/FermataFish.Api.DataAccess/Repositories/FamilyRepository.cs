using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
	public class FamilyRepository: AbstractFamilyRepository, IFamilyRepository
	{
		public FamilyRepository(
			ILogger<FamilyRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>2d70dd863eb5b5ff9cb80dfffa304865</Hash>
</Codenesium>*/