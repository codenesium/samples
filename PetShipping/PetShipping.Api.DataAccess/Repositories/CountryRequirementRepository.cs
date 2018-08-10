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
    <Hash>d604119f79d5ca99ae90f641d617a256</Hash>
</Codenesium>*/