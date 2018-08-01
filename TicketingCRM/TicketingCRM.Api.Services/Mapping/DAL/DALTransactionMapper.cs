using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class DALTransactionMapper : DALAbstractTransactionMapper, IDALTransactionMapper
	{
		public DALTransactionMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>1d6ddbcc675d7044fe7d872e6e08b276</Hash>
</Codenesium>*/