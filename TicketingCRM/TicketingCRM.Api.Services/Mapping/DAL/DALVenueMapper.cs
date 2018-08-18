using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class DALVenueMapper : DALAbstractVenueMapper, IDALVenueMapper
	{
		public DALVenueMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>864a4d03e6f15e20158784136d89460e</Hash>
</Codenesium>*/