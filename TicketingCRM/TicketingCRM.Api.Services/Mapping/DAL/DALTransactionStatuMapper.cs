using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class DALTransactionStatuMapper : DALAbstractTransactionStatuMapper, IDALTransactionStatuMapper
	{
		public DALTransactionStatuMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>7ded3498951a0544910d86f74c769194</Hash>
</Codenesium>*/