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
    <Hash>966dc8799719d3c696359fa0438a923d</Hash>
</Codenesium>*/