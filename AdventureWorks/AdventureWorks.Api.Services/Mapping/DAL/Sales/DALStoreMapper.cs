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
    <Hash>af60856a30bfa3543ca322fd0a8a2018</Hash>
</Codenesium>*/