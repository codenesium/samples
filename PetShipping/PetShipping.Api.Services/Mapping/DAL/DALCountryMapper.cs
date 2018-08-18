using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class DALCountryMapper : DALAbstractCountryMapper, IDALCountryMapper
	{
		public DALCountryMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>9365173d06bf9c0f1fbc3d3000509605</Hash>
</Codenesium>*/