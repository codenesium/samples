using Microsoft.EntityFrameworkCore;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class DALSchemaBPersonMapper : DALAbstractSchemaBPersonMapper, IDALSchemaBPersonMapper
	{
		public DALSchemaBPersonMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>9d84a3be698ee1e8a2237bf28a8f15b8</Hash>
</Codenesium>*/