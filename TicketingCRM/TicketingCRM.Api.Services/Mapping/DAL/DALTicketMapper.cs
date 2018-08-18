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
    <Hash>e15eaa152c6d06343dc39b582458e3cf</Hash>
</Codenesium>*/