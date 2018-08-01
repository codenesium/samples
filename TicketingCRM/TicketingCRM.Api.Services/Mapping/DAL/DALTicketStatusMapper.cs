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
    <Hash>b9a8041b35cc75586bfc3fb65252f163</Hash>
</Codenesium>*/