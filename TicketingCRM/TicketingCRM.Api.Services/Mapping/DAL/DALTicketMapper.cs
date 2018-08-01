using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class DALTicketMapper : DALAbstractTicketMapper, IDALTicketMapper
	{
		public DALTicketMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>eb78373053531b9106d285d24bac1a48</Hash>
</Codenesium>*/