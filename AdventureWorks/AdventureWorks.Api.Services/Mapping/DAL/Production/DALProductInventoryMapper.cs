using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALProductInventoryMapper : DALAbstractProductInventoryMapper, IDALProductInventoryMapper
	{
		public DALProductInventoryMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>43a05376fce188294ed8582e09ae5fc8</Hash>
</Codenesium>*/