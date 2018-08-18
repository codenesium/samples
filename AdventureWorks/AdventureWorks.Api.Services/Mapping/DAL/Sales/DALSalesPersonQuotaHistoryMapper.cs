using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALSalesPersonQuotaHistoryMapper : DALAbstractSalesPersonQuotaHistoryMapper, IDALSalesPersonQuotaHistoryMapper
	{
		public DALSalesPersonQuotaHistoryMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>037cb48b064cb41fd848e83c593d07d7</Hash>
</Codenesium>*/