using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class DALTicketStatusMapper : DALAbstractTicketStatusMapper, IDALTicketStatusMapper
	{
		public DALTicketStatusMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>73f85f7b48b10accd344decd86c838ab</Hash>
</Codenesium>*/