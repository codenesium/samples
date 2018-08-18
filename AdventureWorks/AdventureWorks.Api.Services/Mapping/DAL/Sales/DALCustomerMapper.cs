using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALCustomerMapper : DALAbstractCustomerMapper, IDALCustomerMapper
	{
		public DALCustomerMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>135bf427ab1c0b8d34f4c215dc6ba687</Hash>
</Codenesium>*/