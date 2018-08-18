using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALProductVendorMapper : DALAbstractProductVendorMapper, IDALProductVendorMapper
	{
		public DALProductVendorMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>1b30c9f273c7b7ba823cb629b17ac607</Hash>
</Codenesium>*/