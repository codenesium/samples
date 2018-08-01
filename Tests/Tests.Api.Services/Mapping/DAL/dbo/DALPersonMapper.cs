using Microsoft.EntityFrameworkCore;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class DALPersonMapper : DALAbstractPersonMapper, IDALPersonMapper
	{
		public DALPersonMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>d9e29c0be4adab3736c6d3733b51d7ee</Hash>
</Codenesium>*/