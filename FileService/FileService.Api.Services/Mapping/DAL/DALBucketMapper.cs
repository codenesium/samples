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
    <Hash>00f28ac710fe3cb0ea38a4f43d5491e2</Hash>
</Codenesium>*/