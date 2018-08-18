using Microsoft.EntityFrameworkCore;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class DALPersonRefMapper : DALAbstractPersonRefMapper, IDALPersonRefMapper
	{
		public DALPersonRefMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>30773156e18e7cd9b36c8c31516757aa</Hash>
</Codenesium>*/