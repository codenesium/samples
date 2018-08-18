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
    <Hash>8b3968218853e35e7556e77957e079f9</Hash>
</Codenesium>*/