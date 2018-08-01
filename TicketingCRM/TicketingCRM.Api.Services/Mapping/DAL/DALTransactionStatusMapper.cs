using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class DALTransactionStatusMapper : DALAbstractTransactionStatusMapper, IDALTransactionStatusMapper
	{
		public DALTransactionStatusMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>f11da501854c732d0d133dc743cb77f7</Hash>
</Codenesium>*/