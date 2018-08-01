using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial class CityRepository : AbstractCityRepository, ICityRepository
	{
		public CityRepository(
			ILogger<CityRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c356b25e2f3ae30830215f25444d7c0d</Hash>
</Codenesium>*/