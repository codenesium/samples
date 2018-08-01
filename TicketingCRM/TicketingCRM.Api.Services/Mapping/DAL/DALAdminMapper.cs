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
    <Hash>1fbd65583656d1847a0ffe6062a100de</Hash>
</Codenesium>*/