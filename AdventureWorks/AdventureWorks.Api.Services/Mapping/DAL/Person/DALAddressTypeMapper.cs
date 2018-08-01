using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALAddressTypeMapper : DALAbstractAddressTypeMapper, IDALAddressTypeMapper
	{
		public DALAddressTypeMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>323225743d5c71839cfbda32423f3e02</Hash>
</Codenesium>*/