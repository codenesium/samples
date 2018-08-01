using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace FileServiceNS.Api.Services
{
	public partial class DALFileMapper : DALAbstractFileMapper, IDALFileMapper
	{
		public DALFileMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>a949ff609477aba8576c119abbf1f0a0</Hash>
</Codenesium>*/