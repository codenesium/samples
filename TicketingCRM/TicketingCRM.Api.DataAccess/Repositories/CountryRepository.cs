using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>ac01e3ee30f6224aa34563208af5ec4b</Hash>
</Codenesium>*/