using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace FileServiceNS.Api.Services
{
	public partial class DALBucketMapper : DALAbstractBucketMapper, IDALBucketMapper
	{
		public DALBucketMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>814a902f48ea8a7e8eb2e0d7ca3b1275</Hash>
</Codenesium>*/