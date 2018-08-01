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
    <Hash>dd45c08ab63726451201488859ac0a14</Hash>
</Codenesium>*/