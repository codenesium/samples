using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALErrorLogMapper : DALAbstractErrorLogMapper, IDALErrorLogMapper
	{
		public DALErrorLogMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>2d2f57f03f6b939ee9298cf48cdbc88e</Hash>
</Codenesium>*/