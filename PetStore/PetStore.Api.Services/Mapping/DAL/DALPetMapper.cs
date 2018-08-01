using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public partial class DALPetMapper : DALAbstractPetMapper, IDALPetMapper
	{
		public DALPetMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>8c06635a0403fdba09b129ef9c7bb407</Hash>
</Codenesium>*/