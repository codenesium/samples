using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALSalesPersonMapper : DALAbstractSalesPersonMapper, IDALSalesPersonMapper
	{
		public DALSalesPersonMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>54382779568ed81526cfd62a0f9ec117</Hash>
</Codenesium>*/