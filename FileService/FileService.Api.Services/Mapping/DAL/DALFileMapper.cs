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
    <Hash>b318c45af74585c3682b73a59a66c7f6</Hash>
</Codenesium>*/