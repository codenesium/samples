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
    <Hash>1bf0fd536c01eccf39413b992f30106a</Hash>
</Codenesium>*/