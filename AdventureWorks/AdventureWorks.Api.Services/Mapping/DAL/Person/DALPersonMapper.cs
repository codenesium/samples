using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALPersonMapper : DALAbstractPersonMapper, IDALPersonMapper
	{
		public DALPersonMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>a1d9b1559d9eb9cec89ff18aa1345a99</Hash>
</Codenesium>*/