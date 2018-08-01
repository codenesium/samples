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
    <Hash>45a5a533c6d1f7b9fd19e1b413afea97</Hash>
</Codenesium>*/