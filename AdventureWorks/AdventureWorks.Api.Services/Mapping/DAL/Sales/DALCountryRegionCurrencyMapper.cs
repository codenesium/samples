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
    <Hash>0373d0c87d8bb0fefa1f405af4cee36a</Hash>
</Codenesium>*/