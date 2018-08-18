using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class DALSaleTicketsMapper : DALAbstractSaleTicketsMapper, IDALSaleTicketsMapper
	{
		public DALSaleTicketsMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>6c730373169abdc1bc48f65b33c47010</Hash>
</Codenesium>*/