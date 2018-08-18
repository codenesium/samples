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
    <Hash>b1e5e56bfecfc3a6a0e80bad08c8f928</Hash>
</Codenesium>*/