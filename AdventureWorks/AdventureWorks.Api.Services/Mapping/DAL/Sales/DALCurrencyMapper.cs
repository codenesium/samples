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
    <Hash>488b7cb0e7a85f726d553b945613c564</Hash>
</Codenesium>*/