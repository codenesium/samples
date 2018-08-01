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
    <Hash>6a739aef685dc690cf9c6d5c804acf76</Hash>
</Codenesium>*/