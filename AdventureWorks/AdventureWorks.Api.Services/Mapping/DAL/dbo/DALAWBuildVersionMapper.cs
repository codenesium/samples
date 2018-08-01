using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALAWBuildVersionMapper : DALAbstractAWBuildVersionMapper, IDALAWBuildVersionMapper
	{
		public DALAWBuildVersionMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>dc01336ee2faa13150aa46284d6ef39e</Hash>
</Codenesium>*/