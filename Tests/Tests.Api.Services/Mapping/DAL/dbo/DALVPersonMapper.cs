using Microsoft.EntityFrameworkCore;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class DALVPersonMapper : DALAbstractVPersonMapper, IDALVPersonMapper
	{
		public DALVPersonMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>1fbae773e657340ebe67b32094b48193</Hash>
</Codenesium>*/