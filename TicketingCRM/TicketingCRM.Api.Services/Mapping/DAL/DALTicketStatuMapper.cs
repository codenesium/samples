using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class DALTicketStatuMapper : DALAbstractTicketStatuMapper, IDALTicketStatuMapper
	{
		public DALTicketStatuMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>b929d76f159a58066c14b75e427a6824</Hash>
</Codenesium>*/