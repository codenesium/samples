using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class VenueService : AbstractVenueService, IVenueService
	{
		public VenueService(
			ILogger<IVenueRepository> logger,
			IVenueRepository venueRepository,
			IApiVenueRequestModelValidator venueModelValidator,
			IBOLVenueMapper bolvenueMapper,
			IDALVenueMapper dalvenueMapper
			)
			: base(logger,
			       venueRepository,
			       venueModelValidator,
			       bolvenueMapper,
			       dalvenueMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6bd0c3459e60323c3414d4fb43296d4c</Hash>
</Codenesium>*/