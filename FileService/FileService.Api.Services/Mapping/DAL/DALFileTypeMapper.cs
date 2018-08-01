using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace FileServiceNS.Api.Services
{
	public partial class DALFileTypeMapper : DALAbstractFileTypeMapper, IDALFileTypeMapper
	{
		public DALFileTypeMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>f56b12cea6e0cb675d4f5142c247c9c1</Hash>
</Codenesium>*/