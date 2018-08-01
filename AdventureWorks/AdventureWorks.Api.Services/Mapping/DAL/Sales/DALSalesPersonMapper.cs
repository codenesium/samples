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
    <Hash>60a24c5cae65ba6113b4ce0cdab6373f</Hash>
</Codenesium>*/