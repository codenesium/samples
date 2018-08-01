using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALSalesOrderDetailMapper : DALAbstractSalesOrderDetailMapper, IDALSalesOrderDetailMapper
	{
		public DALSalesOrderDetailMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>e1eb0f0f99170890cdd699fa89197295</Hash>
</Codenesium>*/