using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALProductModelMapper : DALAbstractProductModelMapper, IDALProductModelMapper
	{
		public DALProductModelMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>47d7107bf87f968d1b5d0a1332442863</Hash>
</Codenesium>*/