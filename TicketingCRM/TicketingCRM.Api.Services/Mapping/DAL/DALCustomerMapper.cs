using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class DALCustomerMapper : DALAbstractCustomerMapper, IDALCustomerMapper
	{
		public DALCustomerMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>a69130ecfa6c1f318db46639451e701c</Hash>
</Codenesium>*/