using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALPurchaseOrderHeaderMapper : DALAbstractPurchaseOrderHeaderMapper, IDALPurchaseOrderHeaderMapper
	{
		public DALPurchaseOrderHeaderMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>e067c0f090af8adde81dd7dfc6dfbd32</Hash>
</Codenesium>*/