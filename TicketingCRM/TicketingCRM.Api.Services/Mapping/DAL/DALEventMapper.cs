using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class DALEventMapper : DALAbstractEventMapper, IDALEventMapper
	{
		public DALEventMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>845e243dfe13c6dc3339092d6a0c44b0</Hash>
</Codenesium>*/