using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
	public class CountryRequirementRepository: AbstractCountryRequirementRepository, ICountryRequirementRepository
	{
		public CountryRequirementRepository(
			ILogger<CountryRequirementRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>b11d2a1a8c508846af2a8a751663a201</Hash>
</Codenesium>*/