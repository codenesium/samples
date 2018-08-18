using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALAddressTypeMapper : DALAbstractAddressTypeMapper, IDALAddressTypeMapper
	{
		public DALAddressTypeMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>7b17d20bb1d3626512d46abcfb10bc9e</Hash>
</Codenesium>*/