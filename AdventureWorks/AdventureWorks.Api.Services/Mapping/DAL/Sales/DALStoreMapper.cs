using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALStoreMapper : DALAbstractStoreMapper, IDALStoreMapper
	{
		public DALStoreMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>ea5ec79e44c1be4541ef2c4e7b3a0940</Hash>
</Codenesium>*/