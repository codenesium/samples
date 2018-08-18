using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALSalesTaxRateMapper : DALAbstractSalesTaxRateMapper, IDALSalesTaxRateMapper
	{
		public DALSalesTaxRateMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>df95f6090993a6ea4912a93b2256c7d7</Hash>
</Codenesium>*/