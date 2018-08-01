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
    <Hash>d9830d13103344ac4c7826914ed10ccb</Hash>
</Codenesium>*/