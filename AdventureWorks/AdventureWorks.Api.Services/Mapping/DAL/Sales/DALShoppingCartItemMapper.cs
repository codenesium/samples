using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALShoppingCartItemMapper : DALAbstractShoppingCartItemMapper, IDALShoppingCartItemMapper
	{
		public DALShoppingCartItemMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>a0c2216367453dbe36cf206a82eca5e6</Hash>
</Codenesium>*/