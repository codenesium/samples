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
    <Hash>cab95a1a2840b262ed859366ed5267b4</Hash>
</Codenesium>*/