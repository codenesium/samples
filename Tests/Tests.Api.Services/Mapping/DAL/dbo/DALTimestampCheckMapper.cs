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
    <Hash>719439536c4fe549ee5297944121e95e</Hash>
</Codenesium>*/