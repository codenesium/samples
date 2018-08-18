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
    <Hash>ce9e31da23c11efd8966a4875ea66317</Hash>
</Codenesium>*/