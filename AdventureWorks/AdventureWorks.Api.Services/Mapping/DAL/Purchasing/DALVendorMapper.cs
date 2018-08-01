using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALVendorMapper : DALAbstractVendorMapper, IDALVendorMapper
	{
		public DALVendorMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>6fa20ccbd8b279b77ee6ace63e03f7a6</Hash>
</Codenesium>*/