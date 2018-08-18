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
    <Hash>5651ea1a50a6a542b31e1dba7355b6c3</Hash>
</Codenesium>*/