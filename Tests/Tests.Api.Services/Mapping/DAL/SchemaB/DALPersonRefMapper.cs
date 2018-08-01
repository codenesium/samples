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
    <Hash>fc3b75ab0e1fad7591bf8a78317f68e1</Hash>
</Codenesium>*/