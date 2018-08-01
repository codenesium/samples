using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALSalesTerritoryMapper : DALAbstractSalesTerritoryMapper, IDALSalesTerritoryMapper
	{
		public DALSalesTerritoryMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>26c91639f90512c155ea822c3684e447</Hash>
</Codenesium>*/