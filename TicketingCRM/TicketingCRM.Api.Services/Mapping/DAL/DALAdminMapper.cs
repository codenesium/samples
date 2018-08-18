using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class DALAdminMapper : DALAbstractAdminMapper, IDALAdminMapper
	{
		public DALAdminMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>ff69fa1e17d0d615090e555705ce641c</Hash>
</Codenesium>*/