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
			IApiFamilyModelValidator familyModelValidator)
			: base(logger, familyRepository, familyModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>b064de5dfee19e35ac4166c3a9a4c7ce</Hash>
</Codenesium>*/