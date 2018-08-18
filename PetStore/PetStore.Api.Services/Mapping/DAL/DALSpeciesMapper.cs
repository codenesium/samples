using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public partial class DALSpeciesMapper : DALAbstractSpeciesMapper, IDALSpeciesMapper
	{
		public DALSpeciesMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>30ec0c57d99ba621f9e0f4499a267b92</Hash>
</Codenesium>*/