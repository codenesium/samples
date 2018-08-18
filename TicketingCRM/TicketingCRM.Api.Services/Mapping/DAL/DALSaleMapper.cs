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
    <Hash>7411d81e41c5b6228c5e908da87c5cb9</Hash>
</Codenesium>*/