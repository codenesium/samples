using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALPurchaseOrderDetailMapper : DALAbstractPurchaseOrderDetailMapper, IDALPurchaseOrderDetailMapper
	{
		public DALPurchaseOrderDetailMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>6b3391f50fbd3112809e765b8feb72bf</Hash>
</Codenesium>*/