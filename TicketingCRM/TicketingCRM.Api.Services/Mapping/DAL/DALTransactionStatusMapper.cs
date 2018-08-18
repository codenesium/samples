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
    <Hash>4e464435d1211dcef55cdb1ba9d72bad</Hash>
</Codenesium>*/