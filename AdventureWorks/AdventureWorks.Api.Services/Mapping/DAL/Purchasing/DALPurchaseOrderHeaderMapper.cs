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
    <Hash>957e62410b2f5f979080743becf99973</Hash>
</Codenesium>*/