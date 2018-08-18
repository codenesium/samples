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
    <Hash>86883961350934eea01b249834913ff9</Hash>
</Codenesium>*/