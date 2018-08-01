using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALProductSubcategoryMapper : DALAbstractProductSubcategoryMapper, IDALProductSubcategoryMapper
	{
		public DALProductSubcategoryMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>efd1f9928fa7ac263fd3b95cfd4c9a1c</Hash>
</Codenesium>*/