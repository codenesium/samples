using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALEmailAddressMapper : DALAbstractEmailAddressMapper, IDALEmailAddressMapper
	{
		public DALEmailAddressMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>a918a8cbe2906749b9ab764fdb23b615</Hash>
</Codenesium>*/