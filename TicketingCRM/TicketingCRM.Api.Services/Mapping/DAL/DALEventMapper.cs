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
    <Hash>6fcc8f1c8a0d10ffd80c23bb275f52e6</Hash>
</Codenesium>*/