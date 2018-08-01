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
    <Hash>92f4157d09ba43d3e2b9638ca4335672</Hash>
</Codenesium>*/