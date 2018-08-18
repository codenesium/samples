using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial class CountryRequirementRepository : AbstractCountryRequirementRepository, ICountryRequirementRepository
	{
		public CountryRequirementRepository(
			ILogger<CountryRequirementRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>52eec97c2a7f93053f681f8e7d4ffb9a</Hash>
</Codenesium>*/