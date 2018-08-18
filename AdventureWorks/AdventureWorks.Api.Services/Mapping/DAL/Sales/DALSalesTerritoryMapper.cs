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
    <Hash>7bd45c309e4539449d3de5c3d8dd0de9</Hash>
</Codenesium>*/