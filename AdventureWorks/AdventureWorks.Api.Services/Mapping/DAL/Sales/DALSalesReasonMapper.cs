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
    <Hash>7ce906be56f525b0dd08e872265b3de1</Hash>
</Codenesium>*/