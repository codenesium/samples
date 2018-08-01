using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALAddressMapper : DALAbstractAddressMapper, IDALAddressMapper
	{
		public DALAddressMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>cbac37cb81028f63d1abab73abf583ac</Hash>
</Codenesium>*/