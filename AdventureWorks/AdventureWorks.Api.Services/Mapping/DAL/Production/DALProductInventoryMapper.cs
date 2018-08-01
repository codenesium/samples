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
    <Hash>c5229024cdc1887cb627ed1410a5a2cd</Hash>
</Codenesium>*/