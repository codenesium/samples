using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class TicketStatuService : AbstractTicketStatuService, ITicketStatuService
	{
		public TicketStatuService(
			ILogger<ITicketStatuRepository> logger,
			ITicketStatuRepository ticketStatuRepository,
			IApiTicketStatuRequestModelValidator ticketStatuModelValidator,
			IBOLTicketStatuMapper bolticketStatuMapper,
			IDALTicketStatuMapper dalticketStatuMapper,
			IBOLTicketMapper bolTicketMapper,
			IDALTicketMapper dalTicketMapper
			)
			: base(logger,
			       ticketStatuRepository,
			       ticketStatuModelValidator,
			       bolticketStatuMapper,
			       dalticketStatuMapper,
			       bolTicketMapper,
			       dalTicketMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c62d1ed13f4a7d96e66d8a8372c8209f</Hash>
</Codenesium>*/