using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALWorkOrderRoutingMapper : DALAbstractWorkOrderRoutingMapper, IDALWorkOrderRoutingMapper
	{
		public DALWorkOrderRoutingMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>4f9799c93626cdcc30a9cb8ae8d7b503</Hash>
</Codenesium>*/