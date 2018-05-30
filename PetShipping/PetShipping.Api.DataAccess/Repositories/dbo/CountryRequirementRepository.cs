using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public class CountryRequirementRepository: AbstractCountryRequirementRepository, ICountryRequirementRepository
	{
		public CountryRequirementRepository(
			IDALCountryRequirementMapper mapper,
			ILogger<CountryRequirementRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>37ad2b5451f7b199dcd4269e1cfd6ead</Hash>
</Codenesium>*/