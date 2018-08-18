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
    <Hash>f898a165360df369ae5581368414d460</Hash>
</Codenesium>*/