using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALBusinessEntityAddressMapper : DALAbstractBusinessEntityAddressMapper, IDALBusinessEntityAddressMapper
	{
		public DALBusinessEntityAddressMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>1c243f87d191e03bd3c5ede0e0c69f5f</Hash>
</Codenesium>*/