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
			IDALTicketMapper dalTicketMapper)
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
    <Hash>196667d94f85bed740d7a02b69711749</Hash>
</Codenesium>*/