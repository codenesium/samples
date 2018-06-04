using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public class DALSalesOrderHeaderMapper: AbstractDALSalesOrderHeaderMapper, IDALSalesOrderHeaderMapper
	{
		public DALSalesOrderHeaderMapper()
		{}
	}
}

/*<Codenesium>
    <Hash>69b8354e5280e0cccf6fe6829ac1140f</Hash>
</Codenesium>*/