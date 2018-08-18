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
    <Hash>6f2e86b1d25b2e191fa10d8c60098088</Hash>
</Codenesium>*/