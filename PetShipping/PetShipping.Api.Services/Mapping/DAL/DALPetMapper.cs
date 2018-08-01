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
    <Hash>55b54c950006caea0ee4198ffee32ac5</Hash>
</Codenesium>*/