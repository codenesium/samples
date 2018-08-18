using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALProductCategoryMapper : DALAbstractProductCategoryMapper, IDALProductCategoryMapper
	{
		public DALProductCategoryMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>4327ba3342b84e13efbfda6f086c88d5</Hash>
</Codenesium>*/