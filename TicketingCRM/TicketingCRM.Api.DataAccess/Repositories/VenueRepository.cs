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
    <Hash>2d6418f66aca5b4a4a0428a241270531</Hash>
</Codenesium>*/