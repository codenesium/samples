using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALCurrencyMapper : DALAbstractCurrencyMapper, IDALCurrencyMapper
	{
		public DALCurrencyMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>a189794d4a34ff8ad8afd76ade8accc5</Hash>
</Codenesium>*/