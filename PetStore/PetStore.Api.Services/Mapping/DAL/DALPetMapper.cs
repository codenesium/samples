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
    <Hash>65aa87b452182e2914b1367922741e81</Hash>
</Codenesium>*/