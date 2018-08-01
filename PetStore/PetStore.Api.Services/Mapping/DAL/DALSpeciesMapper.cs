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
    <Hash>0e2b5ca4a6af2eedbcc1465ec2a08e2c</Hash>
</Codenesium>*/