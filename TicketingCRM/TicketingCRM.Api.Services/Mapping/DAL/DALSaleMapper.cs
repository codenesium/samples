using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class DALSaleMapper : DALAbstractSaleMapper, IDALSaleMapper
	{
		public DALSaleMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>a22c36fabb1416845bb6330913006754</Hash>
</Codenesium>*/