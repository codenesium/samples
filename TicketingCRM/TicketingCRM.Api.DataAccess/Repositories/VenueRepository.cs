using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial class VenueRepository : AbstractVenueRepository, IVenueRepository
	{
		public VenueRepository(
			ILogger<VenueRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5be72ca3c9dc8d5fd0fbab5dbbde9865</Hash>
</Codenesium>*/