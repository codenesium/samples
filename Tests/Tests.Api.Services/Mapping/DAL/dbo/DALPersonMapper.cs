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
    <Hash>cab6eac7a1703975fa75e07b42d98c5d</Hash>
</Codenesium>*/