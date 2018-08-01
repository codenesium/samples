using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
	public partial class CountryRepository : AbstractCountryRepository, ICountryRepository
	{
		public CountryRepository(
			ILogger<CountryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3219e170331b362d0244895702da1ae7</Hash>
</Codenesium>*/