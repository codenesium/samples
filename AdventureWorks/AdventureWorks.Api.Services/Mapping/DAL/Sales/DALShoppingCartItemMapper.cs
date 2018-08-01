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
    <Hash>f38633bf8c6ae95960648e91621f7fc8</Hash>
</Codenesium>*/