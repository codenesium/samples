using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public class FamilyRepository: AbstractFamilyRepository, IFamilyRepository
	{
		public FamilyRepository(
			IDALFamilyMapper mapper,
			ILogger<FamilyRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>95bd42c3a9d4af3152659b7ef50d44f2</Hash>
</Codenesium>*/