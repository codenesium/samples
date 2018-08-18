using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class DALPetMapper : DALAbstractPetMapper, IDALPetMapper
	{
		public DALPetMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>e6ae6a72325c398074f2f416ee8709c8</Hash>
</Codenesium>*/