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
    <Hash>b882cc690755165c7f2124ee1295f52a</Hash>
</Codenesium>*/