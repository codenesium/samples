using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALCurrencyRateMapper : DALAbstractCurrencyRateMapper, IDALCurrencyRateMapper
	{
		public DALCurrencyRateMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>d374b61979c515eab67806069c524d32</Hash>
</Codenesium>*/