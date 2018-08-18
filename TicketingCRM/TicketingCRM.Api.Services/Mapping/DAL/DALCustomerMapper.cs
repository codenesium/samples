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
    <Hash>fcfcc4b04ed24f76fac4c5154ba2e62a</Hash>
</Codenesium>*/