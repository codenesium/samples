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
    <Hash>78a367525c00ede2e5a6af293eb848eb</Hash>
</Codenesium>*/