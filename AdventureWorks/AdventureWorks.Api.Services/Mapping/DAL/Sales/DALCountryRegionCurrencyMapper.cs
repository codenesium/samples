using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALCountryRegionCurrencyMapper : DALAbstractCountryRegionCurrencyMapper, IDALCountryRegionCurrencyMapper
	{
		public DALCountryRegionCurrencyMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>fe3dca1e53c5ec7c9994f01a2fccd62e</Hash>
</Codenesium>*/