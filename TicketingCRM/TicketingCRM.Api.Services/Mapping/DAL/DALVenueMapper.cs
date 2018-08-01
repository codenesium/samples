using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class DALVenueMapper : DALAbstractVenueMapper, IDALVenueMapper
	{
		public DALVenueMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>f37970eb5b93e7c88fdba05f47c0be16</Hash>
</Codenesium>*/