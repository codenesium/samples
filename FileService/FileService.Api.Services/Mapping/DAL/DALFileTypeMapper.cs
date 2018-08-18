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
    <Hash>b0fe5ecf5b22497e3927b60ca3665296</Hash>
</Codenesium>*/