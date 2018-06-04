using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public class FamilyService: AbstractFamilyService, IFamilyService
	{
		public FamilyService(
			ILogger<FamilyRepository> logger,
			IFamilyRepository familyRepository,
			IApiFamilyRequestModelValidator familyModelValidator,
			IBOLFamilyMapper BOLfamilyMapper,
			IDALFamilyMapper DALfamilyMapper)
			: base(logger, familyRepository,
			       familyModelValidator,
			       BOLfamilyMapper,
			       DALfamilyMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>ae699eed7dbdf9d74507925ce6b57340</Hash>
</Codenesium>*/