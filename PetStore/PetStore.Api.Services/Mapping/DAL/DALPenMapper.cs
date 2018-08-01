using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public partial class DALPenMapper : DALAbstractPenMapper, IDALPenMapper
	{
		public DALPenMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>437ddec551cfe7126b51ce8269f2e9b3</Hash>
</Codenesium>*/