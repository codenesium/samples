using Microsoft.EntityFrameworkCore;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class DALCompositePrimaryKeyMapper : DALAbstractCompositePrimaryKeyMapper, IDALCompositePrimaryKeyMapper
	{
		public DALCompositePrimaryKeyMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>f607a9f0ceefe208116d95b7f94bc498</Hash>
</Codenesium>*/