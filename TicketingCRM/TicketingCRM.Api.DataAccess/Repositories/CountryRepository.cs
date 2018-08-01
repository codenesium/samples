using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
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
    <Hash>a8c6d2fa1b21504ef9b722b4be7c5a6c</Hash>
</Codenesium>*/