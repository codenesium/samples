using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class DALSaleTicketMapper : DALAbstractSaleTicketMapper, IDALSaleTicketMapper
	{
		public DALSaleTicketMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>cf9ccfeb24b29606f4bbed7b5733da2f</Hash>
</Codenesium>*/