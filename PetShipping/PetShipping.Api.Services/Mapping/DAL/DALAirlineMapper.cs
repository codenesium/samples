using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class DALAirlineMapper : DALAbstractAirlineMapper, IDALAirlineMapper
	{
		public DALAirlineMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>7e3005bb62c228a17ff72a1e68445c20</Hash>
</Codenesium>*/