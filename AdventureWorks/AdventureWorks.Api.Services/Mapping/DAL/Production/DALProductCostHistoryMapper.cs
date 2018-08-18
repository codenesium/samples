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
    <Hash>24c163e24cd5bcc6686db3ee05323b1d</Hash>
</Codenesium>*/