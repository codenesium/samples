using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALProductMapper : DALAbstractProductMapper, IDALProductMapper
	{
		public DALProductMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>243b105ee57b3de29b446360ef5d7a94</Hash>
</Codenesium>*/