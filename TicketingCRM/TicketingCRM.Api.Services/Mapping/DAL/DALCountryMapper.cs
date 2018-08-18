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
    <Hash>324a6b2a79e1d9ee0a830e868848a94c</Hash>
</Codenesium>*/