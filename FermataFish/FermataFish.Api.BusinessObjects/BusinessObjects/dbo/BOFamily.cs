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
			IFamilyModelValidator familyModelValidator)
			: base(logger, familyRepository, familyModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>681d5857469238bf01755f98c08b1853</Hash>
</Codenesium>*/