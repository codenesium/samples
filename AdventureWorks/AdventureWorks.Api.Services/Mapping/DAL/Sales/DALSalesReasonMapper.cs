using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALSalesReasonMapper : DALAbstractSalesReasonMapper, IDALSalesReasonMapper
	{
		public DALSalesReasonMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>c735de008249d3bf021cc555d177dd3f</Hash>
</Codenesium>*/