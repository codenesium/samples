using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALSalesOrderHeaderMapper : DALAbstractSalesOrderHeaderMapper, IDALSalesOrderHeaderMapper
	{
		public DALSalesOrderHeaderMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>32c521537e2690bf227e59c0283abf6c</Hash>
</Codenesium>*/