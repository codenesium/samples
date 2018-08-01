using Microsoft.EntityFrameworkCore;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class DALTableMapper : DALAbstractTableMapper, IDALTableMapper
	{
		public DALTableMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>68bf06c75371babaca7f3c215f99468d</Hash>
</Codenesium>*/