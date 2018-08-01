using Microsoft.EntityFrameworkCore;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class DALTimestampCheckMapper : DALAbstractTimestampCheckMapper, IDALTimestampCheckMapper
	{
		public DALTimestampCheckMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>1c0396acd1acc98f14a9df4d294c299b</Hash>
</Codenesium>*/