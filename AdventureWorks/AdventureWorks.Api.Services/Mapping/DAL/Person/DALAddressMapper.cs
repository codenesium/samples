using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALAddressMapper : DALAbstractAddressMapper, IDALAddressMapper
	{
		public DALAddressMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>f6c4c0463f759886b57122738dfba697</Hash>
</Codenesium>*/