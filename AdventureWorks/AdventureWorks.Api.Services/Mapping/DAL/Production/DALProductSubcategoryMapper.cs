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
    <Hash>375fb64a55f2975470b3c4be441ce7ee</Hash>
</Codenesium>*/