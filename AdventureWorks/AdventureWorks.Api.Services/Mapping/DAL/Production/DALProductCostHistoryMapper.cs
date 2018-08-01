using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALProductCostHistoryMapper : DALAbstractProductCostHistoryMapper, IDALProductCostHistoryMapper
	{
		public DALProductCostHistoryMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>c0ef473a9652916e4e6376b40d072a9a</Hash>
</Codenesium>*/