using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALPasswordMapper : DALAbstractPasswordMapper, IDALPasswordMapper
	{
		public DALPasswordMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>3dbe4860b805a54b9a952e925b007c99</Hash>
</Codenesium>*/