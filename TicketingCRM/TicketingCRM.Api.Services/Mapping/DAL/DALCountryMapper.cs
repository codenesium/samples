using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class DALCountryMapper : DALAbstractCountryMapper, IDALCountryMapper
	{
		public DALCountryMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>70793507368e611d11077a4ba802c275</Hash>
</Codenesium>*/