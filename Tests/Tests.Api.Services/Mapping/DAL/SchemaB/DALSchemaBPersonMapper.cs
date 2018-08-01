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
    <Hash>755e1c17a42e83c18d310083b700bc11</Hash>
</Codenesium>*/