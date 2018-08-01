using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace FileServiceNS.Api.Services
{
	public partial class DALVersionInfoMapper : DALAbstractVersionInfoMapper, IDALVersionInfoMapper
	{
		public DALVersionInfoMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>e11b872fa9aaf49c6fa3520aa3f7aac4</Hash>
</Codenesium>*/