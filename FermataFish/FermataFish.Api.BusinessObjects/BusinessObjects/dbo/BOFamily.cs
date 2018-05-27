using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class BOFamily: AbstractBOFamily, IBOFamily
	{
		public BOFamily(
			ILogger<FamilyRepository> logger,
			IFamilyRepository familyRepository,
			IApiFamilyRequestModelValidator familyModelValidator,
			IBOLFamilyMapper familyMapper)
			: base(logger, familyRepository, familyModelValidator, familyMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>cab6b27e8f7427da7ed958f8044afd49</Hash>
</Codenesium>*/