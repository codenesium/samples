using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALSalesOrderHeaderSalesReasonMapper : DALAbstractSalesOrderHeaderSalesReasonMapper, IDALSalesOrderHeaderSalesReasonMapper
	{
		public DALSalesOrderHeaderSalesReasonMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>a8c769bbd7b7dccde55fd6fb94f955b6</Hash>
</Codenesium>*/