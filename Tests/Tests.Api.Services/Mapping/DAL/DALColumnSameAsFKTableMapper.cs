using Microsoft.EntityFrameworkCore;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class DALColumnSameAsFKTableMapper : DALAbstractColumnSameAsFKTableMapper, IDALColumnSameAsFKTableMapper
	{
		public DALColumnSameAsFKTableMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>55eaf60dc45d45a4b77d48c5977994ab</Hash>
</Codenesium>*/